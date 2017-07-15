using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerMonster : Monster {

    public float rotationSpeed;

    public override void init(Vector2 center, Vector2 vals, string t = "Player")
    {
        transform.localPosition = center;
        rotationSpeed = vals.x;
    }

    void Update ()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
    }
}
