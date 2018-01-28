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
        //tring reply = "";
       
        return replies[Letter.currentChoice];
        //return reply;
        //Check list of selected choices ande give an ideal sequence of choice
    }
    
}
