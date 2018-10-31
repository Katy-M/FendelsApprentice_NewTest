using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    // music
    public AudioClip bg0;
    public AudioClip bg1;
    public AudioClip bg2;

    // volume to play at
    public float volume = 5;

    // the audio source
    private AudioSource source;

    // Use this for initialization
    void Start () {
        // get the audio source
        source = gameObject.GetComponent<AudioSource>();
    }


    // start background 0
    public void StartZero()
    {
        // cancel any invoke calls
        CancelInvoke();

        source.clip = bg0;
        source.Play();
    }

    // start background 1
    public void StartOne()
    {
        source.clip = bg1;
        source.Play();

        // wait for two cycles of bg 1, then play bg2
        Invoke("StartTwo", bg1.length * 2.0f);
    }

    // start background 1
    public void StartTwo()
    {
        source.clip = bg2;
        source.Play();

        // wait for one cycle of bg 2, then play bg2
        Invoke("StartOne", bg2.length * 1.0f);
    }
}
