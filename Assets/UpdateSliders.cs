using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpdateSliders : MonoBehaviour
{
    public SettingsData settings;
    public SliderData[] sliders;

    void Start()
    {
         for (int i=0;i<sliders.Length;i++)
         {
            sliders[i].slider.value = PlayerPrefs.GetFloat(sliders[i].label);
         }  
    }

    public void SliderChanged(string name) {
        PlayerPrefs.SetFloat(name, 1);
    }
}

[Serializable]
public class SliderData {
    public Slider slider;
    public string label;
}