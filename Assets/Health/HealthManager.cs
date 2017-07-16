using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    private static HealthManager instance;

    public float health;
    public float maxHealth = 100;
    public float decayRate = 10;
    public float healthGainFromBullets = 10;
    public float healthLostFromBullets = 20;
    public float healthLostFromEnemies = 40;

    private bool playerAlive = true;

	void Start ()
    {
        playerAlive = true;
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
        playerAlive = true;
        health = maxHealth / 2;
    }

    void Update()
    {
        if (playerAlive)
        {
            health -= decayRate * Time.deltaTime * TimeManager.TimeScale;

            if (health <= 0)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        print("Dead!!");
        health = 0;
        TimeManager.TimeScale = 0.01f;
        GameObject.Find("Player").GetComponent<Player_Movement>().BroadcastMessage("Die");
        playerAlive = false;
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

    public static void increaseHealth(float health)
    {
        if (instance.playerAlive)
        {
            instance.health += health;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }

    public static HealthManager Instance
    {
        get { return instance; }
    }

}
