using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5;

    void Start()
    {
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime * TimeManager.TimeScale;
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        if (position.x < 0 || position.x > 1 || position.y < 0 || position.y > 1)
        {

            gameObject.SetActive(false);
        }
    }

    public void init(Vector2 pos, float dir, float s = 5)
    {
        transform.position = pos;
        transform.eulerAngles = new Vector3(0, 0, dir);
        speed = s;
    }
}
