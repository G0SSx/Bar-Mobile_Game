using _Code.Counters.Logic;
using _Code.KitchenObjects;
using UnityEngine;

namespace _Code.Counters.Services
{
    public interface ICountersFactory
    {
        GameObject CreateCounterOfType(Vector3 position, Quaternion rotation, CounterType type);
        GameObject CreateContainerCounter(Vector3 position, Quaternion rotation, KitchenObjectType type);
        GameObject CreateDeliveryCounter(Vector3 position, Quaternion rotation);
        GameObject CreateCutterCounter(Vector3 position, Quaternion rotation);
        GameObject CreatePlatesCounter(Vector3 position, Quaternion rotation);
        GameObject CreateStoveCounter(Vector3 position, Quaternion rotation);
        GameObject CreateTrashCounter(Vector3 position, Quaternion rotation);
        GameObject CreateClearCounter(Vector3 position, Quaternion rotation);
    }
}