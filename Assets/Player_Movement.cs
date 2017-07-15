using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Use this for initialization

    //Public

    public int interpolationCycle = 10;
    public float defaultInterpolationSpeed = 1.0f;
    public float dashSpeed  = 18.0f;
    public float dashDecayRate = 0.99f;
    public float rotationSpeed  = 4.0f;
    public float dashSpeedEase = 0.98f;
    public float rotationDashDifficulty = 1.5f;

    //Private
    Rigidbody2D mainRB;
    bool[] keys = new bool[255];
    bool superSonic = false;
    float angle = 0.0f;
    int cycle = 0;
    float interpolationSpeed;
    bool interpolated = true;
    float t = 0.5f;
    float currentSpeed = 1;
    float rotationDifficulty = 1.0f;

    void Start () {
        mainRB = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0,0,0);
        interpolationSpeed = defaultInterpolationSpeed;
    }


    void rotationInterpolation()
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
	
	// Update is called once per frame
	void Update ()
    {
        rotationInterpolation();
        
    }

    void resetInterpolation()
    {
        cycle = 0;
        interpolationSpeed = defaultInterpolationSpeed;
        interpolated = true;
    }

    private void FixedUpdate()
    {
        keys[((int)'W')] = Input.GetKey(KeyCode.W);
        keys[((int)'S')] = Input.GetKey(KeyCode.S);
        keys[((int)'A')] = Input.GetKey(KeyCode.A);
        keys[((int)'D')] = Input.GetKey(KeyCode.D);


        if (keys['A'])
        {
            angle += (rotationSpeed / (currentSpeed * rotationDifficulty));
            angle = angle;
            transform.eulerAngles = new Vector3(0, 0, angle);
            resetInterpolation();
        }

        if (keys['D'])
        {
            angle += (-rotationSpeed / (currentSpeed * rotationDifficulty));
            angle = angle;
            transform.eulerAngles = new Vector3(0, 0, angle);
            interpolated = true;
        }

        if (keys['W'] && !superSonic)
        {
            currentSpeed += dashSpeed;
            superSonic = true;
        }

        if (superSonic && currentSpeed > 1.5f)
        {
            rotationDifficulty = rotationDashDifficulty;
            mainRB.velocity = new Vector2(transform.up.x * currentSpeed, transform.up.y * currentSpeed);
            currentSpeed *= dashSpeedEase;
            rotationDifficulty *= dashSpeedEase * 0.72f;
        }
        else if (superSonic && currentSpeed <= 1.5f)
        {
            rotationDifficulty = 1.0f;
            mainRB.velocity = new Vector2(0,0);
            currentSpeed = 1.0f;
            superSonic = false;
        }
        
        if (superSonic && keys['W'])
        { 

        }
    }
}
