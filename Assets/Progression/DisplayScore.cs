using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {

    TextMesh m;

	// Use this for initialization
	void Start () {
        m = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        m.text = ProgressManager.Instance.score.ToString();
	}
}
