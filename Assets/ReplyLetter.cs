using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplyLetter : MonoBehaviour {

    [SerializeField]
    [TextArea]
    public List<string> replies;
    [SerializeField]
    Text replyText;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        replyText.text = ChooseReply();
    }

    private string ChooseReply()
    {
        string reply = "";
        if (Letter.currentChoice == 0)
            reply = replies[0];
        return reply;
        //Check list of selected choices ande give an ideal sequence of choice
    }
    
}
