using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    public int width = 20;
    public int height = 20;

    public int mapWidth;
    public int mapHeight;

    public Texture2D[] mapInfo;
    public Vector3 startPos;

    public GameObject prefabChest;
    public GameObject prefabTrap;
    public GameObject prefabDoor;
    public GameObject[] prefabItems;

    public Texture2D sandTexture;
    public Texture2D grassTexture;

    public float noiseScale = 5f;
    public int tileSize = 1;

    public List<GameObject> chests = new List<GameObject>();
    public List<GameObject> traps = new List<GameObject>();

    public GameManager gameManager;

    private void Start()
    {
        CreateMap();
    }
    void CreateMap()
    {
        mapInfo = Resources.LoadAll<Texture2D>("MapData");

        prefabChest = Resources.Load<GameObject>("Prefabs/Chest");
        prefabDoor = Resources.Load<GameObject>("Prefabs/Door");
        prefabItems = Resources.LoadAll<GameObject>("Prefabs/Items");
        prefabTrap = Resources.Load<GameObject>("Prefabs/Trap");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        sandTexture = CreateTexture(GameData.baseSandColor, GameData.mixSandColor);
        grassTexture = CreateTexture(GameData.baseGrassColor, GameData.mixGrassColor);

        if (!GameData.instance.isGame)
        {
            GameData.instance.stageNum = 0;
            GameData.instance.bagUpgradeNum = 0;
            GameData.instance.bagData.Clear();
            GameData.instance.chestData.Clear();

            foreach (GameObject obj in chests)
            {
                GameData.instance.chestData.Add(true);
            }
        }
        else
        {
            for (int i = 0; i < GameData.instance.chestData.Count; i++)
            {
                chests[i].SetActive(GameData.instance.chestData[i]);
            }
        }
        gameManager.SetChest(GameData.instance.chestData.FindAll(a => a).Count);
        GameData.instance.isGame = true;

        CreateTerrain();
    }
    Texture2D CreateTexture(Color baseColor, Color mixColor)
    {
        Texture2D texture = new Texture2D(GameData.textureWidth, GameData.textureHeight);
        for (int i = 0;i < GameData.textureWidth; i++)
        {
            for(int j = 0;j < GameData.textureHeight; j++)
            {
                float noise = Mathf.PerlinNoise(i, j);
                Color mix = Color.Lerp(baseColor, mixColor, noise);
                texture.SetPixel(i, j, mix);
            }
        }
        texture.Apply();
        return texture;
    }
    void CreateTerrain()
    {

        GameObject map = new GameObject("Map");
        mapHeight = mapInfo[GameData.instance.stageNum].height;
        mapWidth = mapInfo[GameData.instance.stageNum].width;
        GameData.instance.stageSize = mapWidth;

        Color[] pixels = mapInfo[GameData.instance.stageNum].GetPixels();
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                Color pixelColor = pixels[j * mapHeight * i];
                if (pixelColor == GameData.mapLoadSand)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = sandTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";
                }
                else if (pixelColor == GameData.mapLoadGrass)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";
                }
                else if (pixelColor == GameData.mapLoadChest)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = sandTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    GameObject chest = Instantiate
                        (prefabChest, new Vector3(j * tileSize, -0.5f, i * tileSize), prefabChest.transform.rotation);
                    chests.Add (chest);
                    chest.tag = "Chest";
                }
                else if (pixelColor == GameData.mapLoadTrap)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = sandTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    GameObject trap = Instantiate
                        (prefabTrap, new Vector3(j * tileSize, -0.5f, i * tileSize), prefabTrap.transform.rotation);
                    traps.Add (trap);
                    trap.AddComponent<Trap>();
                    trap.tag = "Trap";
                }
                else if (pixelColor == GameData.mapLoadItem)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    int random = Random.Range(0, prefabItems.Length);
                    GameObject item = Instantiate(prefabItems[random],
                        new Vector3(j * tileSize, -0.5f, i * tileSize), prefabTrap.transform.rotation);
                    item.tag = "Item";  
                }
                else if (pixelColor == GameData.mapLoadPatrolEnemy)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    gameManager.monsterCtrl.CreatePatrolEnemy(new Vector3(j * tileSize, -0.5f, i * tileSize));
                }
                else if (pixelColor == GameData.mapLoadAIEnemy)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    gameManager.monsterCtrl.CreateAIEnemy(new Vector3(j * tileSize, -0.5f, i * tileSize));
                }
                else if (pixelColor == GameData.mapLoadStart)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    GameObject start = Instantiate
                        (prefabDoor, new Vector3(j * tileSize, -0.5f, i * tileSize), prefabDoor.transform.rotation);
                    start.tag = "start";
                }
                else if (pixelColor == GameData.mapLoadEnd)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    GameObject end = Instantiate
                        (prefabDoor, new Vector3(j * tileSize, -0.5f, i * tileSize), prefabDoor.transform.rotation);
                    end.tag = "End";
                }
                else if (pixelColor == GameData.mapLoadHurdle)
                {
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.GetComponent<Renderer>().material.mainTexture = grassTexture;
                    block.transform.position = new Vector3(j * tileSize, -1f, i * tileSize);
                    block.transform.parent = map.transform;
                    block.tag = "Ground";

                    GameObject hurdle = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    hurdle.GetComponent<Renderer>().material.mainTexture = sandTexture;
                    hurdle.transform.position = new Vector3(j * tileSize, 0f, i * tileSize);
                    hurdle.transform.parent = map.transform;
                    hurdle.tag = "Hurdle";
                }


            }
        }
    }


}
