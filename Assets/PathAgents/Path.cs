using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector3[] nodes;
    public bool isLoop;

    public Vector3 distanceToPosition(float distance)
    {
        // TODO: does not work for loops
        float[] lengths = new float[nodes.Length-1];
        float sum = 0;
        for (int i=0;i<nodes.Length-1;i++)
        {
            lengths[i] = (nodes[i+1] - nodes[i]).magnitude;
            sum += lengths[i];
        }
        if (distance > sum)
            distance = sum;
        if (distance < 0)
            distance = 0;
        float sumSoFar = 0;
        //float distance = proportion * sum;
        for (int i=0;i<lengths.Length;i++)
        {
            sumSoFar += lengths[i];
            if (sumSoFar >= distance)
            {
                float sectionProportion = 1-((sumSoFar - distance)/lengths[i]);
                return Vector3.Lerp(nodes[i], nodes[i+1], sectionProportion);
            }
        }
        
        return new Vector3();
    }
}
