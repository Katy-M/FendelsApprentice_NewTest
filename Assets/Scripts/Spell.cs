using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

	public int spellID;

	
	public bool isChecked;
	

	public GameObject checkMark;

	public SpellSOList spellCheckmarks;

	[SerializeField]int spellIndex;

	public int SpellIndex{get{return spellIndex;}}

	void Start()
	{
		
		UpdateCheckmark();
	}

	void UpdateCheckmark()
	{
		int count = 0;
		foreach(SpellSO s in spellCheckmarks.spellCheckmarks)
		{
			if(s.spellID==this.spellID)
			{
				isChecked = s.isChecked;
				spellIndex = count;
			}
			count++;
		}
	}


}

