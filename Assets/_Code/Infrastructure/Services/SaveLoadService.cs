using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private const string ProgressKey = "progress";
    private readonly IPersistentProgressService _progressService;
    private readonly IGameFactory _factory;

    public SaveLoadService(IPersistentProgressService progressService, IGameFactory factory)
    {
        _progressService = progressService;
        _factory = factory;
    }

    public void SaveProgress()
    {
        foreach (ISavedProgress progressWriters in _factory.ProgressWriters)
            progressWriters.UpdateProgress(_progressService.Progress);

        PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
    }

    public PlayerProgress LoadProgress() => 
        PlayerPrefs.GetString(ProgressKey)?
            .ToDeserialized<PlayerProgress>();
}