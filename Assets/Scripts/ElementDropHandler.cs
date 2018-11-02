using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementDropHandler : MonoBehaviour, IDropHandler  {

	private AudioManager audio;

    public void OnDrop(PointerEventData eventData)
    {
        audio.PlaySetDown();
    }

    // Use this for initialization
    void Awake () {
		// get AudioManager object
        audio = GameObject.FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
