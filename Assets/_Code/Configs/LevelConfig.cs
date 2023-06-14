using System.Collections.Generic;
using _Code.Data;
using UnityEngine;

namespace _Code.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public string LevelKey;
        public List<CounterSpawnPointData> CountersData;
    }
}