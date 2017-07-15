using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObjectSpawnPool pool;

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Bullet b = pool.getInactivePooledObject().GetComponent<Bullet>();
            b.init(transform.position, Random.Range(0,360));
            b.gameObject.SetActive(true);
        }
	}
}
