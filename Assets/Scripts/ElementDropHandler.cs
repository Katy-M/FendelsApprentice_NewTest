using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementDropHandler : MonoBehaviour, IDropHandler  {
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform elementPanel = transform as RectTransform;

		if(!RectTransformUtility.RectangleContainsScreenPoint(elementPanel,Input.mousePosition))
		{
			Debug.Log("Drop it!");
		}
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
