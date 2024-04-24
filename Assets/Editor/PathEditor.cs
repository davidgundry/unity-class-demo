using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor {

    Tool LastTool = Tool.None;
 
    void OnEnable()
    {
        LastTool = Tools.current;
        Tools.current = Tool.None;
    }
 
    void OnDisable()
    {
        Tools.current = LastTool;
    }

    void OnSceneGUI()
    {
        Path path = (Path) target;
        Handles.color = new Color(255,255,0, 25);
        for (int i=0;i<path.nodes.Length;i++)
        {
            Vector3 newPos = Handles.PositionHandle(path.nodes[i], Quaternion.identity);
            path.nodes[i] = new Vector3(newPos.x, 0, newPos.z);
        }
    }       

    [DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
    static void DrawGizmosSelected(Path path, GizmoType gizmoType)
    {
        for (int i=0;i<path.nodes.Length-1;i++)
            Handles.DrawDottedLine(path.nodes[i], path.nodes[i+1], 3);
        if (path.isLoop)
            Handles.DrawDottedLine(path.nodes[path.nodes.Length-1], path.nodes[0], 3);
    }

    [DrawGizmo(GizmoType.Pickable | GizmoType.NonSelected)]
    static void DrawIcon(Path path, GizmoType gizmoType)
    {
        for (int i=0;i<path.nodes.Length;i++)
            Gizmos.DrawIcon(path.nodes[i], "signpost.png", true);
    }
}