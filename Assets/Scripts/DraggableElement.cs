using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DraggableElement : MonoBehaviour
{

    [HideInInspector] public Element element = null;
    [HideInInspector] public int elementID;


    public TextMeshProUGUI nameText;
    public Image image;

    public ElementDictionary elDic;

    public float hoverColorValue;   // the value to dim the alpha of the icons when they collide.

    SerializableDictionaryExample m_rContainer;
    bool canCollide = false;

    // reference to audio manager
    private AudioManager audio;

    // variable so we only play the noCombo sound once
    private bool soundPlayed = false;

    // ui item reference
    UiItem myItem;

    void Awake()
    {
        m_rContainer = GameObject.FindGameObjectWithTag("RecipeContainer").GetComponent<SerializableDictionaryExample>();

        // get AudioManager object
        audio = GameObject.FindObjectOfType<AudioManager>();

        myItem = GameObject.FindObjectOfType<UiItem>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        nameText.text = element.elementName;
        image.sprite = element.icon;
        elementID = element.elementID;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Image image = gameObject.GetComponent<Image>();
        Color newColor = new Color(image.color.r, image.color.g, image.color.b, 1 - hoverColorValue);
        image.color = newColor;

        if (gameObject.GetComponent<ElementDragHandler>().dragging == false)
            canCollide = false;
        else
            canCollide = true;
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "DraggableElement" && canCollide == true && gameObject.GetComponent<ElementDragHandler>().dragging == false)
        {

            //Destroy(other.gameObject);
            Image image = other.gameObject.GetComponent<Image>();
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, 1);
            image.color = newColor;


            //RecipeDictionary d = new RecipeDictionary();	

            int elementIndex = IsValidRecipe(this, other.gameObject.GetComponent<DraggableElement>());

            if(!(elementIndex==-99))
            {
                other.gameObject.GetComponent<DraggableElement>().image.sprite = elDic.allElements[elementIndex].icon;
                other.gameObject.GetComponent<DraggableElement>().elementID = elDic.allElements[elementIndex].elementID;
                other.gameObject.GetComponent<DraggableElement>().nameText.text = elDic.allElements[elementIndex].elementName;
                other.gameObject.GetComponent<DraggableElement>().element = elDic.allElements[elementIndex];

                //check if this element has not been discovered
                if (!elDic.allElements[elementIndex].active)
                {
                    // set created element to active
                    elDic.allElements[elementIndex].active = true;

                    // add element to UI inventory
                    PopulateGrid unlockedItems = FindObjectOfType<PopulateGrid>();
                    unlockedItems.AddItem(elementIndex);

                    // check if beast pelt
                    if (elementIndex == 62)
                    {
                        // set beast blood and hair to active
                        elDic.allElements[63].active = true;
                        unlockedItems.AddItem(63);
                        elDic.allElements[64].active = true;
                        unlockedItems.AddItem(64);
                    }

                    // check if blood
                    if (elementIndex == 17)
                    {
                        // set beast blood and hair to active
                        elDic.allElements[20].active = true;
                        unlockedItems.AddItem(20);
                    }

                    // Play New discovery sound effect
                    audio.PlayCombo();
                }
                else
                {
                    // play regular Combination sound effect
                    audio.PlayCombo();

                }

                // check if beast pelt
                if (elementIndex == 62)
                {
                    // spawn beast blood and hair
                    myItem.SpawnBeastItem();
                }

                // check if blood
                if (elementIndex == 17)
                {
                    // spawn beast blood and hair
                    myItem.SpawnHumanItem();
                }

                Destroy(this.gameObject);
            }
            else
            {
                // play no combo sound ONCE!!!
                if(!soundPlayed)
                {
                    audio.PlayNoCombo();
                    soundPlayed = true;
                }
            }
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        Image image = gameObject.GetComponent<Image>();
        Color newColor = new Color(image.color.r, image.color.g, image.color.b, image.color.a + hoverColorValue);
        image.color = newColor;

        // reset soundPlayed
        soundPlayed = false;
    }


    public int IsValidRecipe(DraggableElement e1, DraggableElement e2)
    {
        Pair p = new Pair(e1.elementID, e2.elementID);
        int key = -99;

        foreach (Pair v in m_rContainer.RecipeDictionary.Keys)
        {
            if ((v.first == p.first && v.second == p.second)||(v.first==p.second&&v.second==p.first))
            {
                key = m_rContainer.RecipeDictionary[v];
                break;
            }
        }
        //Debug.Log(key);

        // if(m_rContainer.RecipeDictionary.ContainsKey(new Pair(e1.elementID,e2.elementID)))
        // {
        // 	return 36;
        // }
        return key;
    }




}
