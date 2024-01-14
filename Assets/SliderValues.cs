using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValues : MonoBehaviour
{
    [SerializeField] private PlayerClassStats settings;
    [SerializeField] private Slider _slider;
    private void Start()
    {
        _slider.value = settings.health;
    }

    public void ChangeVolume()
    {
        settings.health = _slider.value;
    }
}
