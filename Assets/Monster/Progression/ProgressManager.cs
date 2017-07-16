using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

    private static ProgressManager instance;

    void Start ()
    {
        
    }

    public static ProgressManager Instance
    {
        get { return instance; }
    }

}
