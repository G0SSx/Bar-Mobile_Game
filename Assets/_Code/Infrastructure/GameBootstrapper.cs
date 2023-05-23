using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    public static InputService Input;
    
    private Game _game; // DO ACTUALLY SOMETHING WITH THIS FIELD
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    private IGameFactory _factory;
    private IPersistentProgressService _progressService;

    [Inject]
    private void Construct(IGameFactory factory, IPersistentProgressService progressService)
    {
        _factory = factory;
        _progressService = progressService;
    }

    private void Awake()
    {
        _sceneLoader = new SceneLoader(this);

        _gameStateMachine = new GameStateMachine(_sceneLoader, _factory, _progressService);
        _gameStateMachine.Enter<BootstrapState>();
    }
}