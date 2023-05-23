using UnityEngine;

public class GameLoopState : IState
{
    private readonly GameStateMachine _stateMachine;

    public GameLoopState(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("GameLoopState entered");
    }

    public void Exit()
    {
    }
}