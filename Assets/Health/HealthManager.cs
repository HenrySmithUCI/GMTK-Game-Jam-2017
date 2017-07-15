using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    private static HealthManager instance;

    public float health;
    public float maxHealth = 100;
    public float decayRate = 10;

	void Start ()
    {
        if (null == instance)
        {
            instance = this;
            restart();
        }
        else
        {
            print("Making two singleton gameobject!");
            Destroy(this.gameObject);
        }
	}

    void restart()
    {
        health = maxHealth / 2;
    }

    void Update()
    {
        health -= decayRate * Time.deltaTime * TimeManager.TimeScale;

        if(health <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        print("Dead!!");
        restart();
    }

    public static float Health
    {
        get { return instance.health; }
        set { instance.health = value; }
    }

    public static float MaxHealth
    {
        get { return instance.maxHealth; }
        set { instance.maxHealth = value; }
    }

    public static float DecayRate
    {
        get { return instance.decayRate; }
        set { instance.decayRate = value; }
    }

    public static HealthManager Instance
    {
        get { return instance; }
    }

}
