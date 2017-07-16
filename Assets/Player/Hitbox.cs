using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    public Player_Movement pm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            HealthManager.increaseHealth(-HealthManager.Instance.healthLostFromBullets);
            other.gameObject.SetActive(false);
        }

        if(other.tag == "Monster")
        {
            HealthManager.increaseHealth(-HealthManager.Instance.healthLostFromEnemies);
            other.gameObject.GetComponent<Monster>().die();
        }
    }

    private void Die()
    {
        enabled = false;
    }
}
