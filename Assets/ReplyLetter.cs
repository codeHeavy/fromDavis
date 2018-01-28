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
        if (GameController.begining)
        {
            return "Hi! I’m in town! You wanna catch up? It’s been a while since we wrote and longer since we met. I believe it was the camp? Oh those were fun times. Let me know if you can meet, it’d be nice to be greeted by a familiar face.-JJ, January 2nd, 1981";
        }
        return replies[Letter.currentChoice];
        //return reply;
        //Check list of selected choices ande give an ideal sequence of choice
    }
    
}
