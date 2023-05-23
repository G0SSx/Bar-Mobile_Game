using UnityEngine;

public interface IAssets : IService
{
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 position);
}