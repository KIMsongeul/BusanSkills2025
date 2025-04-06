using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterCtrl monsterCtrl;
    public MapCtrl mapCtrl;

    private void Start()
    {
        InitGame();
    }
    void InitGame()
    {
        mapCtrl = new GameObject("MapCtrl").AddComponent<MapCtrl>();
    }
    public void SetChest(int chestNum)
    {

    }
}
