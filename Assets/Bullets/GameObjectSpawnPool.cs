using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawnPool : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount = 20;

    private List<GameObject> pool;

	void Start ()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < pooledAmount; ++i)
        {
            expandPool();
        }
	}

    private GameObject expandPool()
    { 
        GameObject go = Instantiate(pooledObject, transform);
        go.SetActive(false);
        go.name = pooledObject.name;
        pool.Add(go);
        return go;
    }


	public GameObject getInactivePooledObject()
    {
        foreach(GameObject go in pool)
        {
            if (false == go.activeInHierarchy)
            {
                return go;
            }
        }
        return expandPool();
    }
}
