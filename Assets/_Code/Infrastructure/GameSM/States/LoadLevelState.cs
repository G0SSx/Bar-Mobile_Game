using _Code.Configs;
using _Code.Counters.Services;
using _Code.Data;
using _Code.Infrastructure.Services.Factory;
using _Code.Infrastructure.Services.StaticData;
using _Code.Logic;
using _Code.UI.Services.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code.Infrastructure.GameSM.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _factory;
        private readonly IPersistentProgressService _progressService;
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly ICountersFactory _countersFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory factory,
            IPersistentProgressService progressService, IUIFactory uiFactory, IStaticDataService staticDataService, 
            ICountersFactory countersFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _factory = factory;
            _progressService = progressService;
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
            _countersFactory = countersFactory;
        }

        public void Enter(string sceneName)
        {
            _factory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
            _stateMachine.Enter<GameLoopState>();
        }
    
        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitLevel();
            InformProgressReaders();
        }

        private void InitUIRoot() =>
            _uiFactory.CreateUIRoot();

        private void InitLevel()
        {
            InitPlayer();
            _uiFactory.CreateHud();
            InitCounters();
        }

        private void InitCounters()
        {
            string levelKey = SceneManager.GetActiveScene().name;
            LevelConfig levelConfig = _staticDataService.ForLevel(levelKey);

            foreach (CounterSpawnPointData counter in levelConfig.CountersData)
                _countersFactory.CreateCounterOfType(counter.Position, counter.Rotation, counter.Type,
                    counter.KitchenObjectType);
        }

        private void InitPlayer()
        {
            Vector3 playerPosition = 
                Object.FindObjectOfType<PlayerInitPosition>()
                    .transform.position;

            _factory.CreatePlayer(playerPosition);
        }

        private void InformProgressReaders()
        {
            if (_factory.ProgressReaders == null)
                return;

            foreach (ISavedProgressReader reader in _factory.ProgressReaders)
                reader.LoadProgress(_progressService.Progress);
        }
    }
}