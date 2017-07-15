using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterMonster : Monster {

    public float rotationSpeed;
    public float radius;

    private bool inited = false;
    private Vector2 orbitCenter;
    private float theta;

    public override void init(Vector2 center, Vector2 vals, string t = "Player")
    {
        rotationSpeed = vals.y;
        radius = vals.x;
        orbitCenter = center;
        theta = Random.Range(0, 360);
        transform.localEulerAngles = new Vector3(0, 0, theta - 90);
        inited = true;
    }
	
    void setPos()
    {
        transform.localPosition = orbitCenter - new Vector2(Mathf.Cos(theta * Mathf.PI / 180) * radius, Mathf.Sin(theta * Mathf.PI / 180) * radius);
    }

	void Update ()
    {
        if (false == inited)
        {
            init(transform.position, new Vector2(radius, rotationSpeed));
        }
        transform.localEulerAngles = new Vector3(0, 0, theta - 90);
        transform.localPosition = orbitCenter - new Vector2(Mathf.Cos(theta * Mathf.PI / 180) * radius, Mathf.Sin(theta * Mathf.PI / 180) * radius);
        theta += rotationSpeed * Time.deltaTime * TimeManager.TimeScale;
	}
}
