using System;

namespace _Code.Counters.Logic
{
    [Serializable]
    public enum CounterType
    {
        Unknown = 0,
        Clear = 1,
        Stove = 2,
        Cutter = 3,
        Container = 4,
        Delivery = 5,
        Trash = 6,
        Plates = 7,
    }
}