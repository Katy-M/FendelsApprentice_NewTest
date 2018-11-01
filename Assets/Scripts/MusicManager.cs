using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    // music
    public AudioClip bg0;
    public AudioClip bg1;
    public AudioClip bg2;
    public AudioClip bg3;
    public AudioClip bg4;
    public AudioClip bg5;
    public AudioClip bg6;
    public AudioClip bg7;

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

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for two cycles, then play next track
        if(nextTrack == 0)
        {
            Invoke("StartTwo", bg1.length * 2.0f);
        }
        else if(nextTrack == 1)
        {
            Invoke("StartThree", bg1.length * 2.0f);
        }
        else if(nextTrack == 2)
        {
            Invoke("StartFive", bg1.length * 2.0f);
        }
    }

    // start background 2
    public void StartTwo()
    {
        source.clip = bg2;
        source.Play();

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for one cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg2.length * 1.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartSix", bg2.length * 1.0f);
        }
        else if (nextTrack == 2)
        {
            Invoke("StartSeven", bg2.length * 1.0f);
        }
    }

    // start background 3
    public void StartThree()
    {
        source.clip = bg3;
        source.Play();

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartSix", bg3.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartSeven", bg3.length * 2.0f);
        }
        else if (nextTrack == 2)
        {
            Invoke("StartFour", bg3.length * 2.0f);
        }
    }

    // start background 4
    public void StartFour()
    {
        source.clip = bg4;
        source.Play();

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for one cycle, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartTwo", bg4.length * 1.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartThree", bg4.length * 1.0f);
        }
        else if (nextTrack == 2)
        {
            Invoke("StartFive", bg4.length * 1.0f);
        }
    }

    // start background 5
    public void StartFive()
    {
        source.clip = bg5;
        source.Play();

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg5.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartThree", bg5.length * 2.0f);
        }
        else if (nextTrack == 2)
        {
            Invoke("StartSeven", bg5.length * 2.0f);
        }
    }

    // start background 6
    public void StartSix()
    {
        source.clip = bg6;
        source.Play();

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg6.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartThree", bg6.length * 2.0f);
        }
        else if (nextTrack == 2)
        {
            Invoke("StartSeven", bg6.length * 2.0f);
        }
    }

    // start background 7
    public void StartSeven()
    {
        source.clip = bg7;
        source.Play();

        // generate random number to decide what track to play next (0 - 2)
        float nextTrack = Mathf.Floor(Random.Range(0, 2));

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg7.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartFour", bg7.length * 2.0f);
        }
        else if (nextTrack == 2)
        {
            Invoke("StartSix", bg7.length * 2.0f);
        }
    }
}
