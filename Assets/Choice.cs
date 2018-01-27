using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choice {
    [SerializeField]
    public string sentence;
    [SerializeField]
    public int choiceNumber;
    [SerializeField]
    public int weightage;

    public Choice() { }

    public Choice(string str,int id,int wtg)
    {
        this.sentence = str;
        this.choiceNumber = id;
        this.weightage = wtg;
    }
}
