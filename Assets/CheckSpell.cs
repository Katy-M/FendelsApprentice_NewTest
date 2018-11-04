using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpell : MonoBehaviour {

	[SerializeField] List<Spell> spells;

	public ElementDictionary elDic;

	public GameObject spellText;	// text appears upon discovery of spell.

	public bool canCreateSpells;	// false if player has not created the athame yet.
	// Use this for initialization
	
	// checks if the spell is unlocked and toggles the visibility on the checkmark.
	// returns true if a spell was unlocked.
	public bool IsSpellUnlocked(int key)
	{
		foreach(Spell s in spells)
		{
			if(key==s.spellID)
			{
				return true;
			}
		}

		return false;
	}

	public void ToggleCheckmark(int key)
	{
		if(canCreateSpells==false && key != 88)
			return;

		foreach(Spell s in spells)
		{
			if(key==s.spellID)
			{
				spellText.GetComponent<Timer>().timerOn=true;
				s.isChecked=true;

			}
		}
	}

	private void Update() {
		foreach(Spell s in spells)
		{
			if(s.isChecked==false)
			{
				s.checkMark.SetActive(false);
			}
			else
			{
				s.checkMark.SetActive(true);
			}
		}

        canCreateSpells = true;

	}

	public void ResetSpells()
	{
		foreach(Spell s in spells)
		{
			s.isChecked = false;
		}
	}
}
