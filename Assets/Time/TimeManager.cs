using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    private static TimeManager instance;

    public float timeScale;

    void Start ()
    {
        timeScale = 1;
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            print("Making two singleton gameobject!");
            Destroy(this.gameObject);
        }
    }

    public static float TimeScale
    {
        get { return instance.timeScale; }
        set { instance.timeScale = Mathf.Clamp01(value); }
    }

    public static TimeManager Instance
    {
        get { return instance; }
    }

}
