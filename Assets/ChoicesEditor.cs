using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class ChoicesEditor : EditorWindow {
    
    [MenuItem("Window/AddChoices")]
    public static void ShowWindow()
    {
        GetWindow<ChoicesEditor>("Choices");
    }

    private void OnGUI()
    {
        /*
        GUILayout.Label("Sentence",EditorStyles.boldLabel);
        string sentence = GUILayout.TextArea("Enter choice here",200);
        GUILayout.Label("Choice ID", EditorStyles.boldLabel);
        string choiceNumber = GUILayout.TextField("Enter choice Id");
        int choiceId = Int32.Parse(choiceNumber);
        //GUILayout.Label("Choice Weight", EditorStyles.boldLabel);
        //int choiceWeight = Convert.ToInt32(GUILayout.TextField("Enter choice weight"));

        if (GUILayout.Button("Add New"))
        {
            //Choices.route.Add(new Choice(sentence,choiceNumber,choiceWeight));
        }
        */
    }

    public void CreateNewChoice()
    {
        
    }
}
