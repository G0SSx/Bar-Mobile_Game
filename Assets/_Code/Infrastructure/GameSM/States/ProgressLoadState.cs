public class ProgressLoadState : IState
{
    private readonly GameStateMachine _stateMachine;

    public ProgressLoadState(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
}