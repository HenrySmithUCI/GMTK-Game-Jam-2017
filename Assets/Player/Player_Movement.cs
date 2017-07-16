using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Use this for initialization

    //Public

    [Header("Rotation Info")]
    public int interpolationCycle = 10;
    public float defaultInterpolationSpeed = 1.0f;
    public float highRotationSpeed = 200f;
    public float lowRotationSpeed = 100f;

    [Header("Dash Info")]
    public AnimationCurve dashRate;
    public float maxDashSpeed;
    public float dashMaxTime;
    public Clock dashTime;
    public Color normalColor;
    public Color superSonicColor;
    public bool superSonic;

    public GameObjectSpawnPool playerBulletPool = null;

    //Private
    //Rigidbody2D mainRB;
    SpriteRenderer sr;
    bool[] keys = new bool[255];
    //float angle = 0.0f;
    float currentSpeed = 0;
    float rotationSpeed  = 4.0f;

    void Start () {
        dashTime = new Clock(dashMaxTime);
        dashTime.maxOut();
        sr = GetComponent<SpriteRenderer>();
        if (playerBulletPool == null)
        {
            playerBulletPool = GameObject.Find("PlayerBulletPool").GetComponent<GameObjectSpawnPool>();
        }
    }


    private void Update()
    {
        //rotationInterpolation();
        TimeManager.TimeScale = 0.2f + (currentSpeed / maxDashSpeed);
        sr.color = Color.Lerp(normalColor, superSonicColor, currentSpeed / maxDashSpeed);

        keys[((int)'W')] = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        keys[((int)'S')] = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        keys[((int)'A')] = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        keys[((int)'D')] = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        if ((!superSonic) && keys['W'])
        {

            GameObject bullet = playerBulletPool.getInactivePooledObject();
            Bullet playerBullet = bullet.GetComponent<Bullet>();
            playerBullet.init(new Vector2(transform.position.x, transform.position.y), Mathf.Atan2(transform.up.y, transform.up.x) * (180 / Mathf.PI), 12.0f);
            bullet.SetActive(true);
        }

        if (keys['A'])
        {
            transform.eulerAngles += new Vector3(0, 0, (rotationSpeed / (currentSpeed + 0.2f)) * Time.deltaTime * TimeManager.TimeScale);
        }

        if (keys['D'])
        {
                transform.eulerAngles += new Vector3(0, 0, (-rotationSpeed / (currentSpeed + 0.2f)) * Time.deltaTime * TimeManager.TimeScale);
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !superSonic)
        {
            goSupersonic();
        }

        currentSpeed = dashRate.Evaluate(dashTime.Value / dashMaxTime) * maxDashSpeed;

        if (superSonic && currentSpeed <= dashRate.keys[1].value)
        {
            stopSupersonic();
        }

        if(dashTime.tick(Time.deltaTime))
        {
            dashTime.maxOut();
            dashTime.paused = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotationSpeed = lowRotationSpeed;
        }
        else
        {
            rotationSpeed = highRotationSpeed;
        }

        transform.position += transform.up * currentSpeed * Time.deltaTime * TimeManager.TimeScale;
        
    }


    void goSupersonic()
    {
        superSonic = true;

        
        dashTime.reset();
        dashTime.paused = false;
    }

    void stopSupersonic()
    {
        superSonic = false;
    }

    private void Die()
    {
        for (int i = 0; i < 20; i++)
        {
            Bullet b = playerBulletPool.getInactivePooledObject().GetComponent<Bullet>();
            b.init(transform.position, Random.Range(0, 360), Random.Range(4f, 6f));
            b.gameObject.SetActive(true);
        }
        TimeManager.TimeScale = 0.1f;
        Destroy(gameObject);
    }
}
