using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ShowPlayerPref : MonoBehaviour
{
    private Slider slider;
    public string key;
    public float defaultValue;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { UpdatePref(); });
        if (PlayerPrefs.HasKey(key))
            slider.value = PlayerPrefs.GetFloat(key);
        else
            slider.value = defaultValue;
    }

    void UpdatePref()
    {
        PlayerPrefs.SetFloat(key, slider.value);
        PlayerPrefs.Save();
    }
}
