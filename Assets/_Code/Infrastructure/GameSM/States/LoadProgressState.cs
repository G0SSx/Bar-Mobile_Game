public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadProgress;

    public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadProgress)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _saveLoadProgress = saveLoadProgress;
    }

    public void Enter()
    {
        LoadProgressOrInitNew();
        _gameStateMachine.Enter<LoadLevelState, string>(GameScenes.GameLevel);
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew()
    {
        _progressService.Progress =
          _saveLoadProgress.LoadProgress()
          ?? new PlayerProgress();
    }
}