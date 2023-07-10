using System.Collections.Generic;
using _Code.Data;
using UnityEngine;

namespace _Code.Infrastructure.Services.Factory
{
    public interface IGameFactory
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject CreatePlayer(Vector3 position);
        GameObject CreateCameras(Vector3 cameraPosition);
        void Cleanup();
    }
}