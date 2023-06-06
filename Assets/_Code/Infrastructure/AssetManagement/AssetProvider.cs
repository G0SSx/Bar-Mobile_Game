using UnityEngine;
using Zenject;

public class AssetProvider : IAssets
{
    private DiContainer _container;

    public AssetProvider(DiContainer container) => 
        _container = container;

    public GameObject Instantiate(string path) =>
        Object.Instantiate(LoadPrefab(path));
    
    public GameObject Instantiate(string path, Transform parent) =>
        Object.Instantiate(LoadPrefab(path), parent);

    public GameObject Instantiate(string path, Vector3 position) =>
        Object.Instantiate(LoadPrefab(path), position, Quaternion.identity);

    public GameObject InstantiateWithZenject(string path) =>
        _container.InstantiatePrefab(LoadPrefab(path));

    public GameObject InstantiateWithZenject(string path, Transform parent) => 
        _container.InstantiatePrefab(LoadPrefab(path), parent);

    public GameObject InstantiateWithZenject(string path, Vector3 position) => 
        _container.InstantiatePrefab(LoadPrefab(path), position, Quaternion.identity, null);

    private GameObject LoadPrefab(string path) =>
        Resources.Load<GameObject>(path);
}