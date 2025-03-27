using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject shop;
    public void StartBtn()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void ShopOpenBtn()
    {
        shop.SetActive(true);
    }
    public void ShopCloseBtn()
    {
        shop.SetActive(false);
    }
    public void O2Item1(int price)
    {
        if (Gold.Instance.SpendGold(price))
        {

        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }
    public void O2Item2(int price)
    {
        if (Gold.Instance.SpendGold(price))
        {

        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }
    public void O2Item3(int price)
    {
        if (Gold.Instance.SpendGold(price))
        {

        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }
    public void BagItem1(int price)
    {
        if (Gold.Instance.SpendGold(price))
        {

        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }
    public void BagItem2(int price)
    {
        if (Gold.Instance.SpendGold(price))
        {

        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }
}
