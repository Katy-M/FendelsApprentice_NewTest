using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateElementDictionary {

	public static int counter = 0;

	[MenuItem("Assets/Create/Element Dictionary")]
	public static ElementDictionary Create()
	{
		ElementDictionary asset = ScriptableObject.CreateInstance<ElementDictionary>();

		Object[] allDictionary = Resources.LoadAll("ScriptObjects/Dictionary", typeof(ElementDictionary));
		counter= allDictionary.Length+1;

		if(counter==1)
			AssetDatabase.CreateAsset(asset,"Assets/Resources/ScriptObjects/Dictionary/ElementDictionary.asset");
		else
			AssetDatabase.CreateAsset(asset,"Assets/Resources/ScriptObjects/Dictionary/ElementDictionary"+counter+".asset");
		counter++;
		AssetDatabase.SaveAssets();
		return asset;
	}
}
