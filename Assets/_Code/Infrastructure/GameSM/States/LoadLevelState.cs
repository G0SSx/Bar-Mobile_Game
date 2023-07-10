using _Code.Configs;
using _Code.Counters;
using _Code.Counters.Logic;
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

        private CameraController InitCameras()
        {
            Vector3 cameraPosition = 
                Object.FindObjectOfType<CameraPosition>()
                    .transform.position;

            return  _factory.CreateCameras(cameraPosition)
                .GetComponent<CameraController>();
        }

        private void InitUIRoot() =>
            _uiFactory.CreateUIRoot();

        private void InitLevel()
        {
            CameraController cameraController = InitCameras();
            InitPlayer();
            _uiFactory.CreateHud();
            InitCounters(cameraController);
        }

        private void InitCounters(CameraController cameraController)
        {
            string levelKey = SceneManager.GetActiveScene().name;
            LevelConfig levelConfig = _staticDataService.ForLevel(levelKey);

            foreach (CounterSpawnPointData counterPoint in levelConfig.CountersData)
            {
                if (counterPoint.Type == CounterType.Container)
                {
                    GameObject containerCounterObject = _countersFactory
                        .CreateContainerCounter(counterPoint.Position, counterPoint.Rotation, counterPoint.KitchenObjectType);

                    ContainerCounter containerCounter = containerCounterObject.GetComponent<ContainerCounter>();
                    containerCounter.SetCameraController(cameraController);
                }
                else
                    _countersFactory.CreateCounterOfType(counterPoint.Position, counterPoint.Rotation, counterPoint.Type);
            }
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