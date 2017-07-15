using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObjectSpawnPool pool;
    public float interval = 0.5f;

    private Clock c;

    void Start()
    {
        c = new Clock(interval);
    }

	void Update () {
        if(c.tick(Time.deltaTime))
        {
            Bullet b = pool.getInactivePooledObject().GetComponent<Bullet>();
            b.init(transform.position, Random.Range(0,360));
            b.gameObject.SetActive(true);
        }
	}
}
