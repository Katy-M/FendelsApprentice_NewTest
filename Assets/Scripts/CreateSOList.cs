using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateSOList {

	public static int counter = 0;

	[MenuItem("Assets/Create/Spell SOList")]
	public static SpellSOList Create()
	{
		SpellSOList asset = ScriptableObject.CreateInstance<SpellSOList>();

		Object[] allDictionary = Resources.LoadAll("ScriptObjects/Dictionary", typeof(SpellSOList));
		counter= allDictionary.Length+1;

		if(counter==1)
			AssetDatabase.CreateAsset(asset,"Assets/Resources/ScriptObjects/Dictionary/SpellSOList.asset");
		else
			AssetDatabase.CreateAsset(asset,"Assets/Resources/ScriptObjects/Dictionary/SpellSOList"+counter+".asset");
		counter++;
		AssetDatabase.SaveAssets();
		return asset;
	}
}