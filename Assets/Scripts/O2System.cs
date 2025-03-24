using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2System : MonoBehaviour
{
    private int O2Speed = 3;
    public Slider O2Slider;

    private void Start()
    {
        O2Slider.maxValue = 400;
        O2Slider.value = O2Slider.maxValue;
    }
    private void FixedUpdate()
    {
        O2Slider.value -= Time.deltaTime * O2Speed;
    }
}
