using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    static int choiceCounter = 3;
    [SerializeField]
    GameObject ReplyLetter;
    [SerializeField]
    Button signMailButton;
    [SerializeField]
    GameObject MessageRecievedButton;
    [SerializeField]
    public float replyWait = 2.0f;
    private static int totalWeightage = 0;

    private string partialText;
    private string fullText = "From Davis";
    public float delay = 0.1f;

    public void Start()
    {
        Choice obj = GetComponent<Choices>().meatOfTheStory[0];

        GameObject.FindGameObjectWithTag("Choice01").GetComponent<ReplaceText>().thisChoice = GetComponent<Choices>().meatOfTheStory[0];
        
        GameObject.FindGameObjectWithTag("Choice02").GetComponentInChildren<ReplaceText>().thisChoice = GetComponent<Choices>().meatOfTheStory[1];
        
        GameObject.FindGameObjectWithTag("Choice03").GetComponentInChildren<ReplaceText>().thisChoice = GetComponent<Choices>().meatOfTheStory[2];
        
    }

    string PopChoicesList(List<string> route)
    {
        string top = route[0];
        route.RemoveAt(0);
        return top;
    }

    public void SignLetter()
    {
        Letter.choiceNumberSelected.Add(Letter.currentChoice);
        totalWeightage += GetWeight();
        signMailButton.interactable = false;
        StartCoroutine(OutputText());
        Letter.letterId++;
        StartCoroutine(WaitForReply());
        Debug.Log(totalWeightage);
    }
    //Unique ID for each choice required
    int GetWeight()
    {
        foreach(Choice c in GetComponent<Choices>().meatOfTheStory)
        {
            if (c.choiceNumber == Letter.currentChoice)
                return c.weightage;
        }
        return 0;
    }
    void UpdateChoices()
    {
        GameObject.FindGameObjectWithTag("Choice01").GetComponent<ReplaceText>().thisChoice = GetComponent<Choices>().meatOfTheStory[choiceCounter++];
        
        GameObject.FindGameObjectWithTag("Choice02").GetComponentInChildren<ReplaceText>().thisChoice = GetComponent<Choices>().meatOfTheStory[choiceCounter++];
        
        GameObject.FindGameObjectWithTag("Choice03").GetComponentInChildren<ReplaceText>().thisChoice = GetComponent<Choices>().meatOfTheStory[choiceCounter++];
    }
    public void ContinueWithLetter()
    {
        signMailButton.GetComponentInChildren<Text>().text = "Sign Mail";
        ReplyLetter.SetActive(false);
        signMailButton.interactable = true;
        //GameObject.FindGameObjectWithTag("Signature").SetActive(true);
    }

    public void RecievedMail()
    {
        MessageRecievedButton.SetActive(false);
        //GameObject.FindGameObjectWithTag("Signature").SetActive(false);
        ReplyLetter.SetActive(true);
        UpdateChoices();
        signMailButton.interactable = true;
    }

    IEnumerator WaitForReply()
    {
        yield return new WaitForSeconds(replyWait);
        MessageRecievedButton.SetActive(true);
    }

    IEnumerator OutputText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            partialText = fullText.Substring(0, i);
            signMailButton.GetComponentInChildren<Text>().text = partialText;
            yield return new WaitForSeconds(delay);
        }
    }
    public void Update()
    {
      //  Debug.Log(Choices.route.Count);
    }
}
