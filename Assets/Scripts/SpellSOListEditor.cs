using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
public class SpellSOListEditor : EditorWindow {

	public SpellSOList spellSOList;
    private int viewIndex = 1;
    
    [MenuItem ("Window/Spell SO List Editor %#e")]
    static void  Init () 
    {
        EditorWindow.GetWindow (typeof (SpellSOListEditor));
    }
    
    void  OnEnable () {
        if(EditorPrefs.HasKey("ObjectPath")) 
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            spellSOList = AssetDatabase.LoadAssetAtPath (objectPath, typeof(SpellSOList)) as SpellSOList;
        }
        
    }
    
    void  OnGUI () {
        GUILayout.BeginHorizontal ();
        GUILayout.Label ("Spell SOList Editor", EditorStyles.boldLabel);
        if (spellSOList != null) {
            if (GUILayout.Button("Show Spell SO List")) 
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = spellSOList;
            }
        }
        if (GUILayout.Button("Open Spell SO List")) 
        {
                OpenItemList();
        }
        if (GUILayout.Button("New Spell SO List")) 
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = spellSOList;
        }
        GUILayout.EndHorizontal ();
        
        if (spellSOList == null) 
        {
            GUILayout.BeginHorizontal ();
            GUILayout.Space(10);
            if (GUILayout.Button("Create New Spell SO List", GUILayout.ExpandWidth(false))) 
            {
                CreateNewItemList();
            }
            if (GUILayout.Button("Open Existing Spell SO List", GUILayout.ExpandWidth(false))) 
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal ();
        }
            
            GUILayout.Space(20);
            
        if (spellSOList != null) 
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
                if (viewIndex < spellSOList.spellCheckmarks.Count) 
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
            if (spellSOList.spellCheckmarks == null)
                Debug.Log("wtf");
            if (spellSOList.spellCheckmarks.Count > 0) 
            {
                GUILayout.BeginHorizontal ();
                viewIndex = Mathf.Clamp (EditorGUILayout.IntField ("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, spellSOList.spellCheckmarks.Count);
                //Mathf.Clamp (viewIndex, 1, elementDictionary.allElements.Count);
                EditorGUILayout.LabelField ("of   " +  spellSOList.spellCheckmarks.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal ();
                
                spellSOList.spellCheckmarks[viewIndex-1].spellID = EditorGUILayout.IntField ("Spell ID", spellSOList.spellCheckmarks[viewIndex-1].spellID, GUILayout.ExpandWidth(false));
                spellSOList.spellCheckmarks[viewIndex-1].isChecked = (bool)EditorGUILayout.Toggle("Is Checked?",spellSOList.spellCheckmarks[viewIndex-1].isChecked,GUILayout.ExpandWidth(false));

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
                GUILayout.Label ("This Spell SO List is Empty.");
            }
        }
        if (GUI.changed) 
        {
            EditorUtility.SetDirty(spellSOList);
        }
    }
    
    void CreateNewItemList () 
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        spellSOList = CreateSOList.Create();
        if (spellSOList) 
        {
            spellSOList.spellCheckmarks = new List<SpellSO>();
            string relPath = AssetDatabase.GetAssetPath(spellSOList);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }
    
    void OpenItemList () 
    {
        string absPath = EditorUtility.OpenFilePanel ("Select Spell SO List", "", "");
        if (absPath.StartsWith(Application.dataPath)) 
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            spellSOList = AssetDatabase.LoadAssetAtPath (relPath, typeof(SpellSOList)) as SpellSOList;
            if (spellSOList.spellCheckmarks == null)
                spellSOList.spellCheckmarks = new List<SpellSO>();
            if (spellSOList) {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem () 
    {
        SpellSO newItem = new SpellSO();
        spellSOList.spellCheckmarks.Add (newItem);
        viewIndex = spellSOList.spellCheckmarks.Count;
    }
    
    void DeleteItem (int index) 
    {
        spellSOList.spellCheckmarks.RemoveAt (index);
    }
}
