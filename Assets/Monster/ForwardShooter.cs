using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardShooter : MonoBehaviour {

    public GameObjectSpawnPool pool;
    public float interval = 0.5f;
    public float thetaRange = 10;

    private Clock c;

    void Start()
    {
        c = new Clock(interval);
        if (pool == null)
        {
            pool = GameObject.Find("BulletPool").GetComponent<GameObjectSpawnPool>();
        }
    }

    void Update () {
        if(c.tick(Time.deltaTime))
        {
            Bullet b = pool.getInactivePooledObject().GetComponent<Bullet>();
            b.init(transform.position, ((Mathf.Atan2(transform.right.y, transform.right.x) * 180 / Mathf.PI) + Random.Range(-thetaRange, thetaRange)), 10);
            b.gameObject.SetActive(true);
        }
    }
}
