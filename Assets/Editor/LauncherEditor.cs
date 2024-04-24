using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor 
{
    void OnSceneGUI()
    {
        Launcher launcher = (Launcher) target;
        DrawOffsetHandle(launcher);
        DrawLauncherTarget(launcher);
        DrawAggroRadius(launcher);
    }       

    private void DrawOffsetHandle(Launcher launcher)
    {
        Transform transform = launcher.transform;
        launcher.Offset = transform.InverseTransformPoint(
            Handles.PositionHandle(
                transform.TransformPoint(launcher.Offset), 
                transform.rotation));
    }

    private void DrawLauncherTarget(Launcher launcher)
    {
        Handles.color = new Color(255,255,0, 25);
        Handles.DrawWireDisc(launcher.Target, Vector3.up, 0.8f);
        Handles.DrawWireDisc(launcher.Target, Vector3.up, 0.6f);
        launcher.Target = Handles.Slider2D(0, launcher.Target, Vector3.zero, Vector3.up,  Vector3.forward, Vector3.right, 1, Handles.CircleHandleCap, Vector2.zero);
    }

    private void DrawAggroRadius(Launcher launcher)
    {
        Handles.color = new Color(255,0,0, 25);
        Handles.DrawWireDisc(launcher.transform.position, Vector3.up, launcher.AggroRadius);
        launcher.AggroRadius = (float)Handles.ScaleValueHandle(launcher.AggroRadius, 
            launcher.transform.position + Vector3.forward * launcher.AggroRadius, 
            Quaternion.identity, 30, Handles.ArrowHandleCap, 1);
    }

    [DrawGizmo(GizmoType.Active)]
    static void DrawOffsetLabel(Launcher launcher, GizmoType gizmoType)
    {
        Vector3 offsetPosition = launcher.transform.position + launcher.Offset;
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");
    }

    [DrawGizmo(GizmoType.Active)]
    static void DrawProjectileLine(Launcher launcher, GizmoType gizmoType)
    {
        Vector3 offsetPosition = launcher.transform.position + launcher.Offset;
        if (launcher.Projectile != null)
        {
            List<Vector3> positions = new();
            Vector3 velocity = launcher.Angle * Vector3.forward * launcher.Velocity;
            Vector3 position = offsetPosition;
            float physicsStep = 0.01f;
            float time;
            bool impact = false;
            for (time = 0f; time <= launcher.Projectile.flightTime; time += physicsStep)
            {
                if (position.y < 0)
                    position = new Vector3(position.x, 0, position.z);
                positions.Add(position);
                if (position.y == 0 && time > 0) {
                    impact = true;
                    break;
                }
                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }
            using (new Handles.DrawingScope(Color.yellow))
            {
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[^1], launcher.Projectile.impactRadius);
                if (impact)
                    Handles.Label(positions[^1], "Estimated Impact ("  + time + "sec)");
            }
        }
    }
}