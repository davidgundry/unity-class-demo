using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TrackSliderValue : MonoBehaviour
{
    public Slider slider;
    private TMPro.TextMeshProUGUI   text;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        slider.onValueChanged.AddListener(delegate { UpdateValue(); });
        text.text = "" + slider.value;
    }

    void UpdateValue()
    {
        text.text = "" + slider.value;
    }
}
