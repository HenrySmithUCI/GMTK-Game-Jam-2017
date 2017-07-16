using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    public MonsterSpawner[] spawners;

    private static ProgressManager instance;

    public int score;

    void Start ()
    {
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

    public void increment()
    {
        score += 1;
        if(score % 5 == 0)
        {
            if (spawners.Length >= score / 5)
            {
                Instantiate(instance.spawners[score / 5]);
                if(score >= 15)
                {
                    
                }
            }
        }
    }

    public static ProgressManager Instance
    {
        get { return instance; }
    }

}
