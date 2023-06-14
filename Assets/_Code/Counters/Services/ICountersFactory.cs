using _Code.Counters.Logic;
using _Code.KitchenObjects;
using UnityEngine;

namespace _Code.Counters.Services
{
    public interface ICountersFactory
    {
        GameObject CreateCountainerCounter(KitchenObjectType type);
        GameObject CreateDeliveryCounter();
        GameObject CreateCutterCounter();
        GameObject CreatePlatesCounter();
        GameObject CreateStoveCounter();
        GameObject CreateTrashCounter();
        GameObject CreateClearCounter();
        GameObject CreateCounterOfType(Vector3 position, Quaternion rotationt, CounterType type,
            KitchenObjectType kitchenObjectType);
    }
}