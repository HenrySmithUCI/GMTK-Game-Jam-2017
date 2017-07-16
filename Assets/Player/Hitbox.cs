using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    public Player_Movement pm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet" && pm.superSonic == false)
        {
            HealthManager.increaseHealth(-HealthManager.Instance.healthLostFromBullets);
            other.gameObject.SetActive(false);
        }

        if(other.tag == "Monster")
        {
            HealthManager.Health = 0;
        }
    }

    private void Die()
    {
        enabled = false;
    }
}
