using UnityEngine;

namespace _Code.Infrastructure.AssetManagement
{
    public interface IAssets
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Transform parent);
        GameObject Instantiate(string path, Vector3 position);
        GameObject InstantiateWithZenject(string path);
        GameObject InstantiateWithZenject(string path, Vector3 position);
        GameObject InstantiateWithZenject(string path, Transform parent);
    }
}