using System.Collections.Generic;
using UnityEngine;

public interface IGameFactory
{
    List<ISavedProgressReader> ProgressReaders { get; }
    List<ISavedProgress> ProgressWriters { get; }

    GameObject CreatePlayer(Vector3 position);
    void Cleanup();
}