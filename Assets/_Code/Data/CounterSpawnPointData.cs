using System;
using _Code.Counters.Logic;
using _Code.KitchenObjects;
using UnityEngine;

namespace _Code.Data
{
    [Serializable]
    public class CounterSpawnPointData
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public CounterType Type;
        public KitchenObjectType KitchenObjectType;

        public CounterSpawnPointData(Vector3 position, Quaternion rotation, CounterType type, 
            KitchenObjectType kitchenObjectType)
        {
            Position = position;
            Type = type;
            KitchenObjectType = kitchenObjectType;
            Rotation = rotation;
        }
    }
}