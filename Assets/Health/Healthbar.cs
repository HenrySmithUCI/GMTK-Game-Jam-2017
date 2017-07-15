using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour {
	
    public float maxWidth = 4;

	void Update ()
    {
        transform.localScale = new Vector3(maxWidth * HealthManager.Health / HealthManager.MaxHealth, transform.localScale.y, 0);
        transform.localPosition = new Vector3((maxWidth / 2) - (transform.localScale.x / 2), transform.localPosition.y, 0); 
	}
}
