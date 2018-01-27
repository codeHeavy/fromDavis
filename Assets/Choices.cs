using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Choices : MonoBehaviour {
    [TextArea]
    public List<string> choices_route01;
    [SerializeField]
    public List<int> weight;

    public List<Choice> meatOfTheStory;

    private void Awake()
    {
        //meatOfTheStory = new List<Choice>();
        for(int i = 0; i < choices_route01.Count; i++)
        {
            meatOfTheStory.Add(new Choice(choices_route01[i], i, weight[i]));
        }
        
    }
}
