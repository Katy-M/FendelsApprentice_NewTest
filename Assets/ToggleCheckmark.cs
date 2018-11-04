using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCheckmark : MonoBehaviour {
	
	List<GameObject> allSpells;
	public static void Toggle(ref GameObject checkMark)
	{
		if(checkMark.active==true)
			checkMark.SetActive(false);
		else
			checkMark.SetActive(true);
	}
}
