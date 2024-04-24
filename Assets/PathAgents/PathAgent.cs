using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PathAgent : MonoBehaviour
{
    public Path path;
    [Range(0f, 1f)] public float proportion;
}
