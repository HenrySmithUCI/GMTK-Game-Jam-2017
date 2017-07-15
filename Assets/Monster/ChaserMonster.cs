using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMonster : Monster {

    public float rotationSpeed;
    public float burstSpeed;
    public float friction = 0.99f;
    public float stopThreshhold = 0.01f;
    public string chaseTag;

    private GameObject toChase;
    private float burstVel;

    public override void init(Vector2 center, Vector2 vals, string t = "Player")
    {
        transform.localPosition = center;
        rotationSpeed = vals.x;
        burstSpeed = vals.y;
        toChase = GameObject.Find(t == "" ? "Player" : t);
    }

    void Update ()
    {
        if(toChase == null)
        {
            init(transform.position, new Vector2(rotationSpeed, burstSpeed), chaseTag == null ? "Player" : chaseTag);
        }
        Vector2 playerDir = toChase.transform.position - transform.position;
        Vector2 toDot = new Vector2(playerDir.y, playerDir.x * -1); //rotate 90 degrees
        float rotDirection = Mathf.Sign(Vector2.Dot(transform.right, toDot));
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime * rotDirection);

        if (burstVel != 0)
        {
            transform.position += transform.right * burstVel * Time.deltaTime;

            burstVel *= friction;
            if (burstVel <= stopThreshhold)
            {
                burstVel = 0;
            }
        }
        else
        {
            burstVel = burstSpeed;
        }
    }


}
