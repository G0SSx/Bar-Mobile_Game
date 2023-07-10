using _Code.Counters.Logic;
using _Code.Infrastructure.AssetManagement;
using _Code.KitchenObjects;
using UnityEngine;

namespace _Code.Counters.Services
{
    public class CountersFactory : ICountersFactory
    {
        private readonly IAssets _assets;

        public CountersFactory(IAssets assets) => 
            _assets = assets;

        public GameObject CreateCounterOfType(Vector3 position, Quaternion rotation, CounterType type)
        {
            switch (type)
            {
                case CounterType.Clear:
                    return CreateClearCounter(position, rotation);
                case CounterType.Stove:
                    return CreateStoveCounter(position, rotation);
                case CounterType.Cutter:
                    return CreateCutterCounter(position, rotation);
                case CounterType.Delivery:
                    return CreateDeliveryCounter(position, rotation);
                case CounterType.Trash:
                    return CreateTrashCounter(position, rotation);
                case CounterType.Plates:
                    return CreatePlatesCounter(position, rotation);
            }

            return null;
        }

        public GameObject CreateContainerCounter(Vector3 position, Quaternion rotation, KitchenObjectType type)
        {
            GameObject counter = _assets.InstantiateWithZenject(AssetPath.ContainerCounter);

            counter.GetComponent<ContainerCounter>()
                .KitchenObjectType = type;

            SetCounterTransform(position, rotation, counter);
            
            return counter;
        }

        public GameObject CreateClearCounter(Vector3 position, Quaternion rotation)
        {
            GameObject counter = _assets.Instantiate(AssetPath.ClearCounter);
            SetCounterTransform(position, rotation,  counter);
            
            return counter;
        }

        public GameObject CreateCutterCounter(Vector3 position, Quaternion rotation)
        {
            GameObject counter = _assets.Instantiate(AssetPath.CutterCounter);
            SetCounterTransform(position, rotation,  counter);
            
            return counter;
        }

        public GameObject CreateDeliveryCounter(Vector3 position, Quaternion rotation)
        {
            GameObject counter = _assets.Instantiate(AssetPath.DeliveryCounter);
            SetCounterTransform(position, rotation,  counter);
            
            return counter;
        }

        public GameObject CreatePlatesCounter(Vector3 position, Quaternion rotation)
        {
            GameObject counter = _assets.Instantiate(AssetPath.PlatesCounter);
            SetCounterTransform(position, rotation,  counter);
            
            return counter;
        }

        public GameObject CreateStoveCounter(Vector3 position, Quaternion rotation)
        {
            GameObject counter = _assets.Instantiate(AssetPath.StoveCounter);
            SetCounterTransform(position, rotation,  counter);
            
            return counter;
        }

        public GameObject CreateTrashCounter(Vector3 position, Quaternion rotation)
        {
            GameObject counter = _assets.Instantiate(AssetPath.TrashCounter);
            SetCounterTransform(position, rotation,  counter);
            
            return counter;
        }

        private static void SetCounterTransform(Vector3 position, Quaternion rotation, GameObject counterObject)
        {
            if (counterObject != null)
            {
                counterObject.transform.position = position;
                counterObject.transform.rotation = rotation;
            }
        }
    }
}