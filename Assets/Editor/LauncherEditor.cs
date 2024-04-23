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
        Transform transform = launcher.transform;
        launcher.offset = transform.InverseTransformPoint(
            Handles.PositionHandle(
                transform.TransformPoint(launcher.offset), 
                transform.rotation));
 
        Handles.color = new Color(255,255,0, 25);
        Handles.DrawWireDisc(launcher.target, Vector3.up, 0.8f);
        Handles.DrawWireDisc(launcher.target, Vector3.up, 0.6f);
        launcher.target = Handles.Slider2D(0, launcher.target, Vector3.zero, Vector3.up,  Vector3.forward, Vector3.right, 1, Handles.CircleHandleCap, Vector2.zero);


        Handles.color = new Color(255,0,0, 25);
        Handles.DrawWireDisc(transform.position, Vector3.up, launcher.aggroRadius);
        launcher.aggroRadius = (float)Handles.ScaleValueHandle(launcher.aggroRadius, 
            launcher.transform.position + Vector3.forward * launcher.aggroRadius, 
            Quaternion.identity, 30, Handles.ArrowHandleCap, 1);

        //launcher.angle = Handles.RotationHandle(launcher.angle, launcher.transform.position + launcher.offset);

        //Handles.Disc(0, Quaternion.identity, launcher.transform.position, Vector3.up, launcher.aggroRadius, true, 25);


        // launcher.aggroRadius = Handles.RadiusHandle(
        //     transform.rotation, 
        //     transform.position, 
        //     launcher.aggroRadius);
    }       

    [DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
    static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType)
    {
        var offsetPosition = launcher.transform.position + launcher.offset;
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");
        if (launcher.projectile != null)
        {
            var positions = new List<Vector3>();
            Vector3 velocity = launcher.angle * Vector3.forward * launcher.velocity;
            Vector3 position = offsetPosition;
            float physicsStep = 0.01f;
            float time;
            bool impact = false;
            for (time = 0f; time <= launcher.projectile.flightTime; time += physicsStep)
            {
                if (position.y < 0)
                    position = new Vector3(position.x, 0, position.z);
                positions.Add(position);
                if (position.y == 0 && time > 0)
                {
                    impact = true;
                    break;
                }

                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }
            using (new Handles.DrawingScope(Color.yellow))
            {
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[positions.Count - 1], launcher.projectile.impactRadius);
                if (impact)
                    Handles.Label(positions[positions.Count - 1], "Estimated Impact ("  +time + "sec)");
            }
        }
    }
}