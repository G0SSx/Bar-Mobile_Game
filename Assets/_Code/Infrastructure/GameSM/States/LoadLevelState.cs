public class LoadLevelState : IPayloadedState<string>
{
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactory _factory;
    private readonly IPersistentProgressService _progressService;

    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory factory,
        IPersistentProgressService progressService)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _factory = factory;
        _progressService = progressService;
    }

    public void Enter(string sceneName)
    {
        _factory.Cleanup();
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit()
    {
    }

    private void OnLoaded()
    {
        InformProgressReaders();
    }

    private void InformProgressReaders()
    {
        foreach (ISavedProgressReader reader in _factory.ProgressReaders)
            reader.LoadProgress(_progressService.Progress);
    }
}