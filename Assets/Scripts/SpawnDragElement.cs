using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDragElement : MonoBehaviour {
	public ElementDictionary elements;

	public void SetID(int id)
	{
		Element currentE = elements.allElements[id];

	}
}
