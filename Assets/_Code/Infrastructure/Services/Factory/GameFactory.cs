using System.Collections.Generic;
using _Code.Data;
using _Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace _Code.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressReaders { get; private set; }
        public List<ISavedProgress> ProgressWriters { get; private set; }

        private readonly IPersistentProgressService _progressService;
        private readonly IAssets _assets;

        public GameFactory(IAssets assets, IPersistentProgressService progressService)
        {
            _assets = assets;
            _progressService = progressService;
        }

        public GameObject CreatePlayer(Vector3 position) =>
            InstantiateRegistered(AssetPath.Player, position);

        public void Cleanup()
        {
            ProgressReaders?.Clear();
            ProgressWriters?.Clear();
        }

        public GameObject CreateCameras(Vector3 cameraPosition) => 
            _assets.Instantiate(AssetPath.Cameras, cameraPosition);

        private GameObject InstantiateRegistered(string path, Vector3 position)
        {
            GameObject gameObject = _assets.InstantiateWithZenject(path, position);
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
}