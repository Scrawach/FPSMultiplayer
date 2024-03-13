using Environment;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SpawnPointMarker))]
    public class SpawnPointMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(SpawnPointMarker spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}