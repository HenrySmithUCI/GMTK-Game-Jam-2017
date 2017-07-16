using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEndLocation : MonoBehaviour {

    public Player_Movement pm;
    public float distance;

	void Start () {
        distance = 0;
        for(float i = 0; i < 1; i += 0.01f)
        {
            distance += 0.01f / 6f * (pm.dashRate.Evaluate(i) + pm.dashRate.Evaluate(i + 0.005f) + pm.dashRate.Evaluate(i + 0.01f));
        }
        distance *= pm.maxDashSpeed * pm.dashMaxTime;
        transform.localPosition = Vector2.up * distance / transform.parent.localScale.y / 2;
        transform.localScale = new Vector3(1, distance, 1) * transform.parent.localScale.y;
	}
}
