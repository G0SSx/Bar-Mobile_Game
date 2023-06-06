using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(LevelConfig))]
public class LevelConfigEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelConfig levelConfig = (LevelConfig)target;

        if (GUILayout.Button("Collect"))
        {
            levelConfig.LevelKey = SceneManager.GetActiveScene().name;

            levelConfig.CountersData = FindObjectsOfType<CounterSpawnPoint>()
                .Select(x => 
                    new CounterSpawnPointData(x.transform.position, x.transform.rotation, x.Type, x.KitchenObjectType))
                .ToList();

            EditorUtility.SetDirty(target);
        }

        if (GUILayout.Button("Create/Update counter spawn points"))
            CreateCountersSpawnPoints();
    }

    private static void CreateCountersSpawnPoints()
    {
        BaseCounter[] counters = FindObjectsOfType<BaseCounter>();
        CounterSpawnPoint[] spawnPoints = FindObjectsOfType<CounterSpawnPoint>();

        foreach (BaseCounter counter in counters)
        {
            CounterSpawnPoint spawnPoint = CreateCounterSpawnPointObject();

            if (IsPointExists(spawnPoints, spawnPoint))
            {
                Destroy(spawnPoint);
                continue;
            }

            SetupSpawnPoint(counter, spawnPoint);
        }
    }

    private static void SetupSpawnPoint(BaseCounter counter, CounterSpawnPoint spawnPoint)
    {
        spawnPoint.name = "SpawnPointFor_" + counter.name;

        spawnPoint.transform.position = counter.transform.position;
        spawnPoint.transform.rotation = counter.transform.rotation;
        spawnPoint.Type = GetCounterType(counter);

        if (counter is ContainerCounter container)
            spawnPoint.KitchenObjectType = container.KitchenObjectType;
    }

    private static bool IsPointExists(CounterSpawnPoint[] spawnPoints, CounterSpawnPoint spawnPoint)
    {
        foreach (CounterSpawnPoint point in spawnPoints)
        {
            if (point.transform.position == spawnPoint.transform.position)
                return true;
        }

        return false;
    }

    private static CounterType GetCounterType(BaseCounter counter)
    {
        switch (counter.GetType().Name)
        {
            case nameof(StoveCounter):
                return CounterType.Stove;
            case nameof(CutterCounter):
                return CounterType.Cutter;
            case nameof(DeliveryCounter):
                return CounterType.Delivery;
            case nameof(ClearCounter):
                return CounterType.Clear;
            case nameof(PlatesCounter):
                return CounterType.Plates;
            case nameof(ContainerCounter):
                return CounterType.Container;
            case nameof(TrashCounter):
                return CounterType.Trash;
            default:
                break;
        }

        return CounterType.Unknown;
    }

    private static CounterSpawnPoint CreateCounterSpawnPointObject()
    {
        GameObject spawnPointObject = new GameObject();

        return spawnPointObject.AddComponent<CounterSpawnPoint>();
    }
}