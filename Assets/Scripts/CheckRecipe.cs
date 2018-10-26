using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRecipe : MonoBehaviour {

	// Use this for initialization
	public ElementDictionary elDic;

	private SerializableDictionaryExample m_rContainer;
	void Start () {
		m_rContainer = GameObject.FindGameObjectWithTag("RecipeContainer").GetComponent<SerializableDictionaryExample>();
	}
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		
	}

	// public void IsValidRecipe(DraggableElement e1, ref DraggableElement e2)
	// {
	// 	// return ocean
	// 	if(e1.elementID==3&&e2.elementID==3)
	// 	{
	// 		e2.element = elDic.allElements[35];
	// 		e2.elementID = elDic.allElements[35].elementID;
	// 		e2.nameText.text = elDic.allElements[35].elementName;
		
	// 	}
	// 	// return heat
	// 	else if(e1.elementID==2&&e2.elementID==2)
	// 	{
	// 		e2.element = elDic.allElements[34];
	// 		e2.elementID = elDic.allElements[34].elementID;
	// 		e2.nameText.text = elDic.allElements[34].elementName;
			
	// 	}
	// 	// return cloud
	// 	else if((e1.elementID==0&&e2.elementID==3)||(e2.elementID==3&&e2.elementID==0))
	// 	{
	// 		e2.element = elDic.allElements[38];
	// 		e2.elementID = elDic.allElements[38].elementID;
	// 		e2.nameText.text = elDic.allElements[38].elementName;
	// 	}
	// }
	
	public int IsValidRecipe(DraggableElement e1, DraggableElement e2)
	{
		Pair p = new Pair(e1.elementID,e2.elementID);
		if(m_rContainer.RecipeDictionary.ContainsKey(p))
		{
			return 34;
		}
		return 32;
	}

}
