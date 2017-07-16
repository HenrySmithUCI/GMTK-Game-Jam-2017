using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAndDecay : MonoBehaviour {
    
    public float rotationSpeed = 90;
    private Clock clock;
    private bool dying;

    public void init (Vector3 pos, Color color, float rotSpeed = 1440, float l = 0.1f) {
        transform.localScale = Vector3.one;
        dying = false;
        rotationSpeed = rotSpeed;
        clock = new Clock(l);
        GetComponent<SpriteRenderer>().color = color;
        transform.position = (Vector3)pos + Vector3.forward;
	}
	
	void Update () {
        if(clock.tick(Time.deltaTime))
        {
            if (dying)
            {
                gameObject.SetActive(false);
            }
            else
                dying = true;
        }
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime * TimeManager.TimeScale);
        if (dying)
        {
            transform.localScale = Vector3.one * (clock.MaxValue - clock.Value) / clock.MaxValue;
        }
	}
}
