using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount = 20;
    public bool willGrow = true;

    List<GameObject> pooledObjects;

    void Awake ()
    {

    }

	void Start ()
    {
        pooledObjects = new List<GameObject>();

        CreatePooledObjects();
	}

    public void DisableAll()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void CreatePooledObjects()
    {
        GameObject obj;

        for (int i = 0; i < pooledAmount; i++)
        {
            obj = Instantiate(pooledObject);
            obj.transform.parent = this.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if(willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
