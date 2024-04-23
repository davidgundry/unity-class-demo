using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathAgent))]
public class PathAgentEditor : Editor {

    void OnSceneGUI()
    {
        PathAgent agent = (PathAgent) target;
        Handles.color = new Color(255,0,0, 25);
        Vector3 targetPosition = agent.path.distanceToPosition(agent.distance);
        Handles.DrawWireDisc(targetPosition, Vector3.up, 0.8f);
        Handles.DrawDottedLine(targetPosition, agent.transform.position, 3);
    }
}