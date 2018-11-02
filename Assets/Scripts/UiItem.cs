using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour {

	[HideInInspector]public string elementName;

	[HideInInspector]public int elementID;

	[HideInInspector]public Sprite sprite;

	public GameObject dragPrefab;		// prefab of the draggable element that is going to be spawn in on click

	public ElementDictionary elements;

	

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		
	}

	public void SpawnDragElement()
	{
		GameObject temp = Instantiate(dragPrefab,Vector3.zero,transform.rotation,GameObject.FindGameObjectWithTag("AllDragObjects").transform);
	
		temp.GetComponent<DraggableElement>().image.sprite = elements.allElements[elementID].icon;
		temp.GetComponent<DraggableElement>().elementID = elements.allElements[elementID].elementID;
		temp.GetComponent<DraggableElement>().nameText.text = elements.allElements[elementID].elementName;
		temp.GetComponent<DraggableElement>().element = elements.allElements[elementID];

		
	} 

    public void SpawnBeastItem()
    {
        GameObject temp = Instantiate(dragPrefab, new Vector3 (3, 0, 0), transform.rotation, GameObject.FindGameObjectWithTag("AllDragObjects").transform);

        temp.GetComponent<DraggableElement>().image.sprite = elements.allElements[63].icon;
        temp.GetComponent<DraggableElement>().elementID = elements.allElements[63].elementID;
        temp.GetComponent<DraggableElement>().nameText.text = elements.allElements[63].elementName;
        temp.GetComponent<DraggableElement>().element = elements.allElements[63];

        GameObject temp2 = Instantiate(dragPrefab, new Vector3(-3, 0, 0), transform.rotation, GameObject.FindGameObjectWithTag("AllDragObjects").transform);

        temp2.GetComponent<DraggableElement>().image.sprite = elements.allElements[64].icon;
        temp2.GetComponent<DraggableElement>().elementID = elements.allElements[64].elementID;
        temp2.GetComponent<DraggableElement>().nameText.text = elements.allElements[64].elementName;
        temp2.GetComponent<DraggableElement>().element = elements.allElements[64];
    }

	
}
