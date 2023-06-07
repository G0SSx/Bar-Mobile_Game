using UnityEngine;
using Zenject;

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