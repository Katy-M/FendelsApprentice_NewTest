using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ElementLoader : MonoBehaviour {

	public List<Element> elementsList;
	public Dictionary<Vector2Int,Element> elements;

	// Use this for initialization
	void Awake () {
		// elementsList = new List<Element>();
		// ElementDictionary dictionary = JsonUtility.FromJson<ElementDictionary>(JsonFileReader.LoadJsonAsResource("Elements/ElementDictionary.json"));
		// foreach(string dictionaryItem in dictionary.elements)
		// {
		// 	LoadItem(dictionaryItem);
		// }

		// foreach(KeyValuePair<Vector2Int,Element> entry in elements)
		// {
		// 	Element temp = elements[entry.Key];
		// }
	}

	public void LoadItem(string path)
	{
		string myLoadedItem = JsonFileReader.LoadJsonAsResource(path);
		Element myElement = JsonUtility.FromJson<Element>(myLoadedItem);
	}
	

}
