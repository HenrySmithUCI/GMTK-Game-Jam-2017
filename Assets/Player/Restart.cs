﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	
	void Update () {
        if (HealthManager.Instance.playerAlive == false && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
	}
}
