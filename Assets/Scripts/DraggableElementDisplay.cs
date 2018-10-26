using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DraggableElementDisplay : MonoBehaviour {

	[HideInInspector] public Element element=null;

	public TextMeshProUGUI nameText;
	public Image image;

	public int elementID;

	bool canCollide = false;

	void Awake()
	{
		
	}
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		nameText.text = element.elementName;
		image.sprite = element.icon;
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Image image = gameObject.GetComponent<Image>();
		Color newColor = new Color(image.color.r,image.color.g,image.color.b,image.color.a-0.2f);
		image.color = newColor;

		if(gameObject.GetComponent<ElementDragHandler>().dragging == false)
			canCollide = false;
		else
			canCollide = true;
	}

	/// <summary>
	/// Sent each frame where another object is within a trigger collider
	/// attached to this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log(gameObject.name);
		if(other.gameObject.tag=="DraggableElement"&&canCollide ==true&&gameObject.GetComponent<ElementDragHandler>().dragging == false)
		{
			Debug.Log(gameObject.name);
			//Destroy(other.gameObject);
			Image image = other.gameObject.GetComponent<Image>();
			Color newColor = new Color(image.color.r,image.color.g,image.color.b,image.color.a+0.2f);
			image.color = newColor;

			//other.gameObject.GetComponent<DraggableElement>().
			Destroy(this.gameObject);
		}
	}

	/// <summary>
	/// Sent when another object leaves a trigger collider attached to
	/// this object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerExit2D(Collider2D other)
	{
		Image image = gameObject.GetComponent<Image>();
		Color newColor = new Color(image.color.r,image.color.g,image.color.b,image.color.a+0.2f);
		image.color = newColor;
	}



}
