using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float rotationSpeed;
    public float forwardSpeed;


    public void init(Vector2 center, float radius, float speed)
    {
        forwardSpeed = speed;
        float theta = Random.Range(0, 360);
        transform.position = center - new Vector2(Mathf.Cos(theta * Mathf.PI / 180) * radius, Mathf.Sin(theta * Mathf.PI / 180) * radius);
        if (speed != 0)
            rotationSpeed = speed / radius * 180 / Mathf.PI;
        else
            rotationSpeed = 0;
        transform.localEulerAngles = new Vector3(0, 0, theta - 90);
    }
	
	void Update ()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        transform.localPosition += transform.right * forwardSpeed * Time.deltaTime;
	}
}
