using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D mainRB;
    bool[] keys = new bool[255];
    bool superSonic = false;
    float angle = 0.0f;
    float rotationSpeed = 2.0f;
    int interpolationCycle = 10;
    int cycle = 0;
    float defaultInterpolationSpeed = 1.0f;
    float interpolationSpeed;
    bool interpolated = true;

    void Start () {
        mainRB = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0,0,0);
        interpolationSpeed = defaultInterpolationSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!(Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.D)))
        {
            if (interpolated && Input.GetKeyUp(KeyCode.A))
            {
                if (interpolationSpeed < 0)
                    interpolationSpeed = -interpolationSpeed;
                interpolated = false;
            }
            else if (interpolated && Input.GetKeyUp(KeyCode.D))
            {
                if (interpolationSpeed > 0)
                    interpolationSpeed = -interpolationSpeed;
                interpolated = false;
            }
        }

        if ((!interpolated) && cycle <= interpolationCycle)
        {
            cycle += 1;
            angle += interpolationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);
            interpolationSpeed *= 0.99f;
        }
        else if (cycle > interpolationCycle)
        {
            resetInterpolation();
        }
        
    }

    void resetInterpolation()
    {
        cycle = 0;
        interpolationSpeed = defaultInterpolationSpeed;
        interpolated = true;
    }

    private void FixedUpdate()
    {
        keys[((int) 'W')] = Input.GetKey(KeyCode.W);
        keys[((int)'S')] = Input.GetKey(KeyCode.S);
        keys[((int)'A')] = Input.GetKey(KeyCode.A);
        keys[((int)'D')] = Input.GetKey(KeyCode.D);
 
           
        if (keys['A'] && !superSonic)
        {
            angle += rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);
            resetInterpolation();
        }
        
        if (keys['D'] && !superSonic)
        {
            angle += -rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);
            interpolated = true;
        }




    }
}
