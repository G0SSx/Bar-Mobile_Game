using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject InstantiateWithZenject(string path)
    {
        GameObject prefab = _container.InstantiatePrefab(LoadPrefab(path));

        MoveObjectToActiveScene(prefab);

        return prefab;
    }

    public GameObject InstantiateWithZenject(string path, Transform parent)
    {
        GameObject prefab = _container.InstantiatePrefab(LoadPrefab(path), parent); ;

        MoveObjectToActiveScene(prefab);

        return prefab; 
    }

    public GameObject InstantiateWithZenject(string path, Vector3 position)
    {
        GameObject prefab = _container.InstantiatePrefab(LoadPrefab(path), position, Quaternion.identity, null);

        MoveObjectToActiveScene(prefab);

        return prefab;
    }

    private void MoveObjectToActiveScene(GameObject prefab)
    {
        if (prefab.transform.parent != null)
            return;

        //After instantiating with DiContainer object for some raeson moved to DontDestoryOnLoad scene
        SceneManager.MoveGameObjectToScene(prefab, SceneManager.GetActiveScene());
    }

    private GameObject LoadPrefab(string path) =>
        Resources.Load<GameObject>(path);
}