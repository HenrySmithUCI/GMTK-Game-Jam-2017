using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour {
    public GameObjectSpawnPool pool;
    public bool parent = false;

    public abstract void init(Vector2 pos, Vector2 vals, string t = "Player");

    public void Start()
    {
        pool = GameObject.Find("BulletPool").GetComponent<GameObjectSpawnPool>();
    }

    public void die()
    {
        if (parent)
        {
            ProgressManager.Instance.increment();
            for (int i = 0; i < 20; i++)
            {
                Bullet b = pool.getInactivePooledObject().GetComponent<Bullet>();
                b.init(transform.position, Random.Range(0, 360), Random.Range(4f, 6f));
                b.gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                Bullet b = pool.getInactivePooledObject().GetComponent<Bullet>();
                b.init(transform.position, Random.Range(0, 360), Random.Range(4f, 6f));
                b.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "playerBullet")
        {
            die();
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
