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
    public void O2Item1()
    {
        
    }
}
