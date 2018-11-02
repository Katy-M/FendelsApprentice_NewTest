using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler{

	Vector3 lastPosition;
	Canvas WorldCanvas;

	public bool dragging;

	private AudioManager audio;

	public /// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		// get AudioManager object
        audio = GameObject.FindObjectOfType<AudioManager>();
		lastPosition = Vector3.zero;
		dragging = false;
		WorldCanvas = GameObject.FindGameObjectWithTag("CameraCanvas").GetComponent<Canvas>();
	}
    public void OnDrag(PointerEventData eventData)
    {
		if(dragging==false)
			audio.PlayPickUp();

		dragging = true;
		Vector3 screenPoint = Input.mousePosition;
		screenPoint.z = WorldCanvas.planeDistance;
		transform.position = WorldCanvas.worldCamera.ScreenToWorldPoint(screenPoint);
		
		// store the last position
		lastPosition = transform.position;
    }

	public void OnEndDrag(PointerEventData eventData)
	{
		dragging = false;
		//audio.PlaySetDown();
		transform.position = lastPosition;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Default Mouse: "+ Input.mousePosition+"  Mouse Mod: "+Camera.main.ScreenToWorldPoint(Input.mousePosition)+"\nLocal Pos:" +transform.localPosition+"  World Pos: "+transform.position);
	}
}
