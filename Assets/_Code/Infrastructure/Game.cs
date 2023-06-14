using _Code.Counters.Services;
using _Code.Data;
using _Code.Infrastructure.GameSM;
using _Code.Infrastructure.Services.Factory;
using _Code.Infrastructure.Services.SaveLoad;
using _Code.Infrastructure.Services.StaticData;
using _Code.UI.Services.Factory;

namespace _Code.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, IGameFactory factory, 
            IPersistentProgressService progressService, ISaveLoadService saveLoadService, 
            IUIFactory uiFactory, ICountersFactory countersFactory, IStaticDataService staticDataService)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), factory, progressService,
                saveLoadService, uiFactory, countersFactory, staticDataService);
        }
    }
}