using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    private MonsterSpawner MMScript;
    public GameObject playerFab;
    private GameObject player;
    private int level = 1;

    public int MonstersKillCount { get; set; }
    public int ExtraMonsters { get { return MonstersKillCount / 10; } }
    public bool BossDead { get; set; }
    public bool PlayerDead { get; set; }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        MMScript = GetComponentInChildren<MonsterSpawner>();
        player = Instantiate(playerFab);
        player.transform.parent = this.transform;

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        DisableChildren();

        //Call the SetupScene function of the BoardManager script, pass it current level number.
        //boardScript.SetupScene(level);        TODO
        MonstersKillCount = 0;
        BossDead = false;
        PlayerDead = false;
        MMScript.Level = level;        

        EnableChildren();
    }

    //Update is called every frame.
    void Update()
    {

    }

    void DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void PlayerKilled()
    {
        PlayerDead = true;
        InitGame();
    }

    public void MonsterKilled()
    {
        MonstersKillCount++;
        MMScript.monstersAlive--;
    }

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }
}