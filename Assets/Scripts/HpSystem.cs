using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public Slider hpSlider;

    private void Start()
    {
        hpSlider.maxValue = maxHp;
        currentHp = maxHp;
        hpSlider.value = maxHp;
    }
    public void Damage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            //Died
        }
    }
    private void Update()
    {
        hpSlider.value = currentHp;
    }
}
