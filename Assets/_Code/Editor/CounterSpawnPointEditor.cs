﻿using _Code.Counters.Logic;
using UnityEditor;
using UnityEngine;

namespace _Code.Editor
{
    [CustomEditor(typeof(CounterSpawnPoint))]
    public class CounterSpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(CounterSpawnPoint point, GizmoType gizmo)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point.transform.position, 0.3f);
        }
    }
}