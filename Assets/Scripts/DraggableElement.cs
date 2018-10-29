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

    void Awake()
    {
        m_rContainer = GameObject.FindGameObjectWithTag("RecipeContainer").GetComponent<SerializableDictionaryExample>();
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
        Color newColor = new Color(image.color.r, image.color.g, image.color.b, image.color.a - hoverColorValue);
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
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, image.color.a + hoverColorValue);
            image.color = newColor;


            //RecipeDictionary d = new RecipeDictionary();	

            int elementIndex = IsValidRecipe(this, other.gameObject.GetComponent<DraggableElement>());

            if(!(elementIndex==-99))
            {
                other.gameObject.GetComponent<DraggableElement>().image.sprite = elDic.allElements[elementIndex].icon;
                other.gameObject.GetComponent<DraggableElement>().elementID = elDic.allElements[elementIndex].elementID;
                other.gameObject.GetComponent<DraggableElement>().nameText.text = elDic.allElements[elementIndex].elementName;
                other.gameObject.GetComponent<DraggableElement>().element = elDic.allElements[elementIndex];
                Destroy(this.gameObject);
            }
            
            
            // check if this element has not been discovered
            //Debug.Log(elDic.allElements[elementIndex]);
           // if (!elDic.allElements[elementIndex].active)
           // {
           //     // set created element to active
           //     elDic.allElements[elementIndex].active = true;
           //
           //     // new discovery sound effect stuff goes here
           //
           //
           //     // add element to UI inventory
           //     PopulateGrid unlockedItems = FindObjectOfType<PopulateGrid>();
           //     unlockedItems.AddItem(elementIndex);
           // }
           // else
           // {
           //     // regular discovery sound effect stuff goes here
           //
           // }


            
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
