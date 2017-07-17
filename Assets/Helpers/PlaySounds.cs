using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour {

    public static PlaySounds instance;

    public AudioClip[] sounds;

    public AudioSource ads;

	void Start () {
        instance = this;
        ads = GetComponent<AudioSource>();
    }
}
