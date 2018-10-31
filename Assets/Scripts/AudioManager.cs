using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // sound effects
    public AudioClip combo;
    public AudioClip newCombo;
    public AudioClip noCombo;
    public AudioClip pickUp;
    public AudioClip setDown;
    public AudioClip trash;

    // volume to play at
    public float volume = 5;

    // the audio source
    private AudioSource source;

	// Use this for initialization
	void Start ()
    {
        // get the audio source
        source = gameObject.GetComponent<AudioSource>();
	}
	
    // play combo sound (Regular Combination)
    public void PlayCombo()
    {
        source.PlayOneShot(combo, volume);
    }

    // play new combo sound (New element discovered)
    public void PlayNewCombo()
    {
        source.PlayOneShot(newCombo, volume);
    }

    // play no combo sound (Items do not combine)
    public void PlayNoCombo()
    {
        source.PlayOneShot(noCombo, volume);
    }

    // play pick up sound (Item was picked up)
    public void PlayPickUp()
    {
        source.PlayOneShot(pickUp, volume);
    }

    // play set down sound (Item was placed down)
    public void PlaySetDown()
    {
        source.PlayOneShot(setDown, volume);
    }

    // play trash sound (Item was trashed/deleted)
    public void PlayTrash()
    {
        source.PlayOneShot(trash, volume);
    }
}
