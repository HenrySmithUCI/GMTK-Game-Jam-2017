using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float rotationSpeed;
    public float forwardSpeed;
	
	void Update () {
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        transform.localPosition += transform.right * forwardSpeed * Time.deltaTime;
	}
}
