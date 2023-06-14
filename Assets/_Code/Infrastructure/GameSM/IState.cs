namespace _Code.Infrastructure.GameSM
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}