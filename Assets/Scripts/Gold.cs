using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public static Gold Instance { get; private set; }

    private int currentGold = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public  void AddGold(int amount)
    {
        currentGold += amount;
        Debug.Log("+" + amount + "���� ��� : " + currentGold);
    }
    public bool SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            Debug.Log("��� ���: " + amount + ", ���� ���: " + currentGold);
            return true;
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
            return false;
        }
    }
}
