using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
public class ElementDictionaryEditor : EditorWindow {

	public ElementDictionary elementDictionary;
    private int viewIndex = 1;
    
    [MenuItem ("Window/Element Dictionary Editor %#e")]
    static void  Init () 
    {
        EditorWindow.GetWindow (typeof (ElementDictionaryEditor));
    }
    
    void  OnEnable () {
        if(EditorPrefs.HasKey("ObjectPath")) 
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            elementDictionary = AssetDatabase.LoadAssetAtPath (objectPath, typeof(ElementDictionary)) as ElementDictionary;
        }
        
    }
    
    void  OnGUI () {
        GUILayout.BeginHorizontal ();
        GUILayout.Label ("Element Dictionary Editor", EditorStyles.boldLabel);
        if (elementDictionary != null) {
            if (GUILayout.Button("Show Element Dictionary")) 
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = elementDictionary;
            }
        }
        if (GUILayout.Button("Open Element Dictionary")) 
        {
                OpenItemList();
        }
        if (GUILayout.Button("New Element Dictionary")) 
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = elementDictionary;
        }
        GUILayout.EndHorizontal ();
        
        if (elementDictionary == null) 
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Space(10);
            if (GUILayout.Button("Create New Element Dictionary", GUILayout.ExpandWidth(false))) 
            {
                CreateNewItemList();
            }
            if (GUILayout.Button("Open Existing Element Dictionary", GUILayout.ExpandWidth(false))) 
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal ();
        }
            
            GUILayout.Space(20);
            
        if (elementDictionary != null) 
        {
            GUILayout.BeginHorizontal ();
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) 
            {
                if (viewIndex > 1)
                    viewIndex --;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) 
            {
                if (viewIndex < elementDictionary.allElements.Count) 
                {
                    viewIndex ++;
                }
            }
            
            GUILayout.Space(60);
            
            if (GUILayout.Button("Add Item", GUILayout.ExpandWidth(false))) 
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false))) 
            {
                DeleteItem(viewIndex - 1);
            }
            
            GUILayout.EndHorizontal ();
            if (elementDictionary.allElements == null)
                Debug.Log("wtf");
            if (elementDictionary.allElements.Count > 0) 
            {
                GUILayout.BeginHorizontal ();
                viewIndex = Mathf.Clamp (EditorGUILayout.IntField ("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, elementDictionary.allElements.Count);
                //Mathf.Clamp (viewIndex, 1, elementDictionary.allElements.Count);
                EditorGUILayout.LabelField ("of   " +  elementDictionary.allElements.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal ();
                
                elementDictionary.allElements[viewIndex-1].elementName = EditorGUILayout.TextField ("Element Name", elementDictionary.allElements[viewIndex-1].elementName as string);
                elementDictionary.allElements[viewIndex-1].icon = EditorGUILayout.ObjectField ("Element Icon", elementDictionary.allElements[viewIndex-1].icon, typeof (Sprite), false) as Sprite;
                elementDictionary.allElements[viewIndex-1].elementID = EditorGUILayout.IntField ("Element ID", elementDictionary.allElements[viewIndex-1].elementID, GUILayout.ExpandWidth(false));
                
                GUILayout.Space(10);
                
                // GUILayout.BeginHorizontal ();
                // elementDictionary.allElements[viewIndex-1].isUnique = (bool)EditorGUILayout.Toggle("Unique", elementDictionary.allElements[viewIndex-1].isUnique, GUILayout.ExpandWidth(false));
                // elementDictionary.allElements[viewIndex-1].isIndestructible = (bool)EditorGUILayout.Toggle("Indestructable", elementDictionary.allElements[viewIndex-1].isIndestructible,  GUILayout.ExpandWidth(false));
                // elementDictionary.allElements[viewIndex-1].isQuestItem = (bool)EditorGUILayout.Toggle("QuestItem", elementDictionary.allElements[viewIndex-1].isQuestItem,  GUILayout.ExpandWidth(false));
                // GUILayout.EndHorizontal ();
                
                // GUILayout.Space(10);
                
                // GUILayout.BeginHorizontal ();
                // elementDictionary.allElements[viewIndex-1].isStackable = (bool)EditorGUILayout.Toggle("Stackable ", elementDictionary.allElements[viewIndex-1].isStackable , GUILayout.ExpandWidth(false));
                // elementDictionary.allElements[viewIndex-1].destroyOnUse = (bool)EditorGUILayout.Toggle("Destroy On Use", elementDictionary.allElements[viewIndex-1].destroyOnUse,  GUILayout.ExpandWidth(false));
                // elementDictionary.allElements[viewIndex-1].encumbranceValue = EditorGUILayout.FloatField("Encumberance", elementDictionary.allElements[viewIndex-1].encumbranceValue,  GUILayout.ExpandWidth(false));
                // GUILayout.EndHorizontal ();
                
                // GUILayout.Space(10);
            
            } 
            else 
            {
                GUILayout.Label ("This Element Dictionary is Empty.");
            }
        }
        if (GUI.changed) 
        {
            EditorUtility.SetDirty(elementDictionary);
        }
    }
    
    void CreateNewItemList () 
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        elementDictionary = CreateElementDictionary.Create();
        if (elementDictionary) 
        {
            elementDictionary.allElements = new List<Element>();
            string relPath = AssetDatabase.GetAssetPath(elementDictionary);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }
    
    void OpenItemList () 
    {
        string absPath = EditorUtility.OpenFilePanel ("Select Element Dictionary", "", "");
        if (absPath.StartsWith(Application.dataPath)) 
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            elementDictionary = AssetDatabase.LoadAssetAtPath (relPath, typeof(ElementDictionary)) as ElementDictionary;
            if (elementDictionary.allElements == null)
                elementDictionary.allElements = new List<Element>();
            if (elementDictionary) {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem () 
    {
        Element newItem = new Element();
        newItem.elementName = "New Item";
        elementDictionary.allElements.Add (newItem);
        viewIndex = elementDictionary.allElements.Count;
    }
    
    void DeleteItem (int index) 
    {
        elementDictionary.allElements.RemoveAt (index);
    }
}
