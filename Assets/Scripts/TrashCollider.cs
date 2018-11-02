using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollider : MonoBehaviour {

	private AudioManager audio;

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	/// <summary>
	/// Sent each frame where another object is within a trigger collider
	/// attached to this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "DraggableElement"&& other.gameObject.GetComponent<ElementDragHandler>().dragging ==false)
		{
			audio.PlayTrash();
			Destroy(other.gameObject);
		}
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		 // get AudioManager object
        audio = GameObject.FindObjectOfType<AudioManager>();
	}
}
