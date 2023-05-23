public class BootstrapState : IState
{
    private const string BootScene = "Boot";
    private const string MenuScene = "Menu";

    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        _sceneLoader.Load(BootScene, EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>(MenuScene);
    }
}