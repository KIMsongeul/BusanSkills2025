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
        currentHp = maxHp;
        hpSlider.value = currentHp/maxHp;
    }
    public void Damage(int damage)
    {
        currentHp -= damage;
        hpSlider.value = currentHp/maxHp;
        if (currentHp <= 0)
        {
            //Died
        }
    }
}
