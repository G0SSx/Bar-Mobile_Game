using System.Collections.Generic;
using UnityEngine;

public class GameFactory : IGameFactory
{
    public List<ISavedProgressReader> ProgressReaders { get; } = new();
    public List<ISavedProgress> ProgressWriters { get; } = new();

    private readonly IAssets _assets;

    public GameFactory(IAssets assets)
    {
        _assets = assets;
    }

    public GameObject CreatePlayer() =>
        InstantiateRegistered(AssetPath.Player);

    public void CreateHud() => 
        InstantiateRegistered(AssetPath.Hud);

    public void Cleanup()
    {
        ProgressReaders.Clear();
        ProgressWriters.Clear();
    }

    private GameObject InstantiateRegistered(string prefabPath, Vector3 position)
    {
        GameObject gameObject = _assets.Instantiate(prefabPath, position);
        RegisterProgressWatchers(gameObject);
        return gameObject;
    }

    private GameObject InstantiateRegistered(string prefabPath)
    {
        GameObject gameObject = _assets.Instantiate(prefabPath);
        RegisterProgressWatchers(gameObject);
        return gameObject;
    }

    private void RegisterProgressWatchers(GameObject gameObject)
    {
        foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            Register(progressReader);
    }

    private void Register(ISavedProgressReader reader)
    {
        if (reader is ISavedProgress progress)
            ProgressWriters.Add(progress);

        ProgressReaders.Add(reader);
    }
}