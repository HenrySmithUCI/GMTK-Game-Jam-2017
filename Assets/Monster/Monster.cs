using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour {
    public GameObjectSpawnPool pool;

    public abstract void init(Vector2 pos, Vector2 vals, string t = "Player");

    public void die()
    {
        gameObject.SetActive(false);
        Bullet b = pool.getInactivePooledObject().GetComponent<Bullet>();
        b.init(transform.position, Random.Range(0, 360));
    }
}
