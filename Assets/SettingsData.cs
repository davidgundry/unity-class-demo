using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Settings")]
public class SettingsData : ScriptableObject
{
    public float fov;

    public void ValueChanged(string name) {

    }
}
