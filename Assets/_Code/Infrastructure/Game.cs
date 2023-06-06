public class Game
{
    public readonly GameStateMachine GameStateMachine;

    public Game(ICoroutineRunner coroutineRunner, IGameFactory factory, 
        IPersistentProgressService progressService, ISaveLoadService saveLoadService, 
        IUIFactory uiFactory, ICountersFactory countersFactory, IStaticDataService staticDataService)
    {
        GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), factory, progressService,
            saveLoadService, uiFactory, countersFactory, staticDataService);
    }
}