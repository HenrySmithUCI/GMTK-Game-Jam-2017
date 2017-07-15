﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 3;

    private float life = 2;

	void FixedUpdate ()
    {
        if(life <= 0)
        {
            gameObject.SetActive(false);
        }

        transform.position += (transform.right + transform.up).normalized * speed * Time.fixedDeltaTime;
        life -= Time.fixedDeltaTime;
	}

    public void init(Vector2 pos, float dir)
    {
        life = 2;
        transform.position = pos;
        transform.eulerAngles = new Vector3(0, 0, dir);
    }
}