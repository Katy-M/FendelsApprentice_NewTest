using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour 
{
	public CheckSpell cSpell;
	public ElementDictionary elDic;

	AudioManager mngr;

	UIMngr ui;

	bool playedSound;	// make sure the win sound only get's played once.

	// Use this for initialization
	void Start () {
		playedSound = false;
		ui = UIMngr.Instance;
		mngr = GameObject.FindObjectOfType<AudioManager>();
	}

	void Awake() {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckWin();
	}

	void CheckWin()
	{
		bool checkE = cSpell.CheckAllUnlocked();

		bool checkS = true;
		foreach(Element e in elDic.allElements)
		{
			if(e.active==false)
				checkS = false;
		}

		if(checkE == true && checkS == true)
		{
			ui.ToggleWinScreen();
			MusicManager music = GameObject.FindObjectOfType<MusicManager>();
            music.GetComponent<AudioSource>().enabled = false;

			if(playedSound==false)
			{
				mngr.PlayNewCombo();
				playedSound=true;
			}
			
		}
	}
}
