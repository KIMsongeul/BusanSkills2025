using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int stageNum;
    public int stageSize;
    public int bagUpgradeNum;
    public bool isGame;
    public bool reset = false;
    public List<Item> bagData;
    public List<bool> chestData;


    public static GameData instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            ResetGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void ResetGame()
    {
        if (!reset)
        {
            stageNum = 0;
            bagUpgradeNum = 0;
            isGame = true;
            bagData = new List<Item>();
            chestData = new List<bool>();

            reset = true;
        }
    }

    
    public static int textureWidth = 256;
    public static int textureHeight = 256;
    

    public static Color baseSandColor;
    public static Color mixSandColor;
    public static Color baseGrassColor;
    public static Color mixGrassColor;

    public static Color mapLoadSand;
    public static Color mapLoadGrass;
    public static Color mapLoadChest;
    public static Color mapLoadTrap;
    public static Color mapLoadItem;
    public static Color mapLoadAIEnemy;
    public static Color mapLoadPatrolEnemy;
    public static Color mapLoadStart;
    public static Color mapLoadEnd;
    public static Color mapLoadHurdle;
    
}
