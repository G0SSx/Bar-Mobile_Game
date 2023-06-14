using System;
using System.Collections.Generic;
using _Code.Counters.Services;
using _Code.Data;
using _Code.Infrastructure.GameSM.States;
using _Code.Infrastructure.Services.Factory;
using _Code.Infrastructure.Services.SaveLoad;
using _Code.Infrastructure.Services.StaticData;
using _Code.UI.Services.Factory;

namespace _Code.Infrastructure.GameSM
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;

        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, IGameFactory factory, IPersistentProgressService progressService, 
            ISaveLoadService saveLoadService, IUIFactory uiFactory, ICountersFactory countersFactory, IStaticDataService staticDataService)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadProgressState)] = new LoadProgressState(this, progressService, saveLoadService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, factory, progressService, uiFactory, 
                    staticDataService, countersFactory),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}