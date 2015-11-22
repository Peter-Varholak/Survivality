using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

    ObjectPooler myObjectPooler;
    GameManager gm;

    public int Level { get; set; }
    float monsterSpawnCD;
    float cooldown;
    int spawnRange;
    public int monstersAlive { get; set; }
    int maxMonsters;

    void Start ()
    {
        myObjectPooler = GetComponent<ObjectPooler>();
        gm = GameManager.instance;
    }

	void OnEnable ()
    {
        monsterSpawnCD = 1.5f;
        cooldown = 0f;
        spawnRange = 10;
        monstersAlive = 0;
        maxMonsters = Level * 15;

        FirstSpawn();
	}

    void OnDisable ()
    {
        myObjectPooler.DisableAll();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((monstersAlive < maxMonsters + gm.ExtraMonsters) && (cooldown <= Time.time))
        {
            SpawnMonster();
            Debug.Log(maxMonsters);
        }
	}

    void FirstSpawn()
    {
        for (int i = 0; i < monstersAlive; i++)
        {
            SpawnMonster();
            monstersAlive--;
            cooldown = 0;
        }
    }

    public void SpawnMonster()
    {
        cooldown = Time.time + monsterSpawnCD;

        GameObject obj = myObjectPooler.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = GetRandomPosition();
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);

        monstersAlive++;
    }

    Vector3 GetRandomPosition()
    {
        float xPos = (float) (Random.Range(15, 51) / 100f) + 1.0f;
        float yPos = (float) (Random.Range(15, 51) / 100f) + 1.0f;
        xPos = ChangePosition(xPos);
        yPos = ChangePosition(yPos);        

        float angle = Random.Range(0.0f, Mathf.PI * 2);

        Vector3 vect = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);

        vect *= spawnRange;
        vect += gm.GetPlayerPosition();

        return vect;
    }

    float ChangePosition (float position)
    {
        if (Random.Range(0, 2) == 0)
        {
            position *= -1;
        }
        else
        {
            position += 1;
        }

        return position;
    }
}
