using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


///<summary> Handles all the toggling of menus </summary>
public class UIMngr : MonoBehaviour
{

    #region Singleton Instance Checks
    //Ensure there is only one instance of the UI manager
    private static UIMngr instance = null;
    public static UIMngr Instance
    {
        get
        {
            //Find the UI manager if it exists
            if(instance == null)
            {
                instance = FindObjectOfType<UIMngr>();
            }
            //Create a new one if it doesn't
            if(instance == null)
            {
                GameObject obj = new GameObject("UIMngr");
                instance = obj.AddComponent<UIMngr>();
            }

            return instance;
        }
    }

    //Ensure the instance is removed when the game is closed
    void OnApplicationQuit()
    {
        instance = null;
    }
    #endregion

    public GameObject hud;
    public GameObject options;
    public GameObject overlay;
    public GameObject mainMenu;
    public GameObject spellBook;

    public ElementDictionary elDic;
    private bool audioOn;
    private GameObject previous;
    

	// Use this for initialization
	void Start ()
    {
        mainMenu.SetActive(true);
        hud.SetActive(false);
        options.SetActive(false);
        spellBook.SetActive(false);
        audioOn = true;
    }

    //Sets the previous menu visited
    public void SetPrevious(GameObject prev)
    {
        previous = prev;
    }
    public void ToggleInstructions(GameObject instructions)
    {
        if (!instructions.active)
        {
            instructions.SetActive(true);

            if (previous != null)
                previous.SetActive(false);
        }
        else
        {
            instructions.SetActive(false);
            if (previous != null)
                previous.SetActive(true);
        }
    }

    public void ToggleSpellbook(GameObject book)
    {
        if (!book.active)
        {
            book.SetActive(true);
            hud.SetActive(false);
        }
        else
        {
            book.SetActive(false);
            hud.SetActive(true);
        }
    }

    #region Main Menu
    public void StartGame()
    {
        //Toggle the HUD
        hud.SetActive(true);
        options.SetActive(false);
        mainMenu.SetActive(false);

        // get reference to music manager and switch music loop
        MusicManager music = GameObject.FindObjectOfType<MusicManager>();
        music.StartOne();
    }

    public void ToggleCredits(GameObject credits)
    {
        if (!credits.active)
        {
            credits.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            credits.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    #endregion

    #region Options Menu
    //Toggles the options menu
    public void ToggleOptions()
    {
        if (hud.active)
        {
            hud.SetActive(false);
            options.SetActive(true);
            overlay.SetActive(true);
        }
        else
        {
            hud.SetActive(true);
            options.SetActive(false);
            overlay.SetActive(false);
        }
    }

    public void ClearBoard()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("DraggableElement");
        for(int i=0;i<allObjects.Length;i++)
        {
            Destroy(allObjects[i]);
        }
    }

    public void ResetIcons()
    {
        for(int i =8;i<elDic.allElements.Count;i++)
        {
            elDic.allElements[i].active = false;
        }
    }

    public void ToggleAudio(Text buttonText)
    {
        if (audioOn)
        {
            buttonText.text = "Off";
            audioOn = false;
            MusicManager music = GameObject.FindObjectOfType<MusicManager>();
            music.volume = 0;
        }
        else
        {
            audioOn = true;
            buttonText.text = "On";
            MusicManager music = GameObject.FindObjectOfType<MusicManager>();
            music.volume = 50;
        }
    }
    #endregion

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
