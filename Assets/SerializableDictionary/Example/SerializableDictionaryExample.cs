using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableDictionaryExample : MonoBehaviour {
	// The dictionaries can be accessed throught a property
	// [SerializeField]
	// StringStringDictionary m_stringStringDictionary;

	[SerializeField]
	RecipeDictionary m_RecipeDictionary;
	// public IDictionary<string, string> StringStringDictionary
	// {
	// 	get { return m_stringStringDictionary; }
	// 	set { m_stringStringDictionary.CopyFrom (value); }
	// }

	// [SerializeField]
	// QuaternionMyClassDictionary m;

	// public IDictionary<Quaternion, MyClass> QuaternionMyClassDictionary
	// {
	// 	get{return m;}
	// 	set{m.CopyFrom(value);}
	// }

	public IDictionary<Pair, int> RecipeDictionary
	{
		get{return m_RecipeDictionary;}
		set{m_RecipeDictionary.CopyFrom(value);}
	}

	//public ObjectColorDictionary m_objectColorDictionary;
	//public StringColorArrayDictionary m_objectColorArrayDictionary;

	void Reset ()
	{
		// access by property
		//StringStringDictionary = new Dictionary<string, string>() { {"first key", "value A"}, {"second key", "value B"}, {"third key", "value C"} };
		//m_objectColorDictionary = new ObjectColorDictionary() { {gameObject, Color.blue}, {this, Color.red} };
		RecipeDictionary = new RecipeDictionary();
	}
}
