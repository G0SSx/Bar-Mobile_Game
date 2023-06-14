using _Code.Counters.Services;
using _Code.Data;
using _Code.Infrastructure.GameSM.States;
using _Code.Infrastructure.Services.Factory;
using _Code.Infrastructure.Services.SaveLoad;
using _Code.Infrastructure.Services.StaticData;
using _Code.UI.Services.Factory;
using UnityEngine;
using Zenject;

namespace _Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private IGameFactory _factory;
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private IUIFactory _uiFactory;
        private ICountersFactory _countersFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IGameFactory factory, IPersistentProgressService progressService, 
            ISaveLoadService saveLoadService, IUIFactory uiFactory, 
            ICountersFactory countersFactory, IStaticDataService staticDataService)
        {
            _factory = factory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _uiFactory = uiFactory;
            _countersFactory = countersFactory;
            _staticDataService = staticDataService;
        }

        private void Awake() => 
            DontDestroyOnLoad(this);

        private void Start()
        {
            _game = new Game(this, _factory, _progressService, _saveLoadService, _uiFactory,
                _countersFactory, _staticDataService);

            _game.GameStateMachine.Enter<LoadProgressState>();
        }
    }
}