using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public static Camera mainCam;
    public float speed = 5;

    void Start()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime * TimeManager.TimeScale;
    }

    public void init(Vector2 pos, float dir, float s = 5)
    {
        transform.position = pos;
        transform.eulerAngles = new Vector3(0, 0, dir);
        speed = s;
    }

    void OnBecameInvisible()
    {
        if (mainCam == Camera.current)
        {
            gameObject.SetActive(false);
        }
    }
}
