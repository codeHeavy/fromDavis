using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour{
    public static List<int> choiceNumberSelected ;
    public static List<Choice> selectedChoices ;
    public static int currentChoice ;
    public static int letterId = 1;
    private void Awake()
    {
        choiceNumberSelected = new List<int>();
        selectedChoices = new List<Choice>();
        currentChoice = 0;
    }
    
}
