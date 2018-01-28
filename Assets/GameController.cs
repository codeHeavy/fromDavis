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
    private static int lastChoice = -1;

    private string partialText;
    private string fullText = "From, Davis";
    public float delay = 0.1f;
    public static bool begining = true;
    public static bool end = false;
    private bool signed = false;
    private bool showEnd = false;

    [SerializeField]
    public Animator newspaperAnim;
    [SerializeField]
    public GameObject newspaperObject;
    [SerializeField]
    public List<Sprite> endNewspaperSprite;

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
        if (lastChoice != Letter.currentChoice)
        {
            GameObject.FindGameObjectWithTag("Choice01").GetComponent<Button>().interactable = false;
            GameObject.FindGameObjectWithTag("Choice02").GetComponent<Button>().interactable = false;
            GameObject.FindGameObjectWithTag("Choice03").GetComponent<Button>().interactable = false;

            Letter.choiceNumberSelected.Add(Letter.currentChoice);
            totalWeightage += GetWeight();
            signMailButton.interactable = false;
            StartCoroutine(OutputText());
            Letter.letterId++;
            StartCoroutine(WaitForReply());
            lastChoice = Letter.currentChoice;
            signed = true;
        }
        //Debug.Log(totalWeightage);
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
        signed = false;
        if (begining)
        {
            signMailButton.GetComponentInChildren<Text>().text = "Sign Mail";
            ReplyLetter.SetActive(false);
            signMailButton.interactable = true;
            begining = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Choice01").GetComponent<Button>().interactable = true;
            GameObject.FindGameObjectWithTag("Choice02").GetComponent<Button>().interactable = true;
            GameObject.FindGameObjectWithTag("Choice03").GetComponent<Button>().interactable = true;

            signMailButton.GetComponentInChildren<Text>().text = "Sign Mail";
            ReplyLetter.SetActive(false);
            signMailButton.interactable = true;
        }
        if(Letter.letterId > 7)
        {
            showEnd = true;
        }
    }

    public void RecievedMail()
    {
        ReplyLetter.SetActive(true);
        if(signed)
            UpdateChoices();
        signMailButton.interactable = true;
    }

    IEnumerator WaitForReply()
    {
        yield return new WaitForSeconds(replyWait);
        MessageRecievedButton.SetActive(true);
        MessageRecievedButton.GetComponent<AudioSource>().Play();
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
  
    public void EndGame(int ending)
    {
        //Show Newspaper
        newspaperAnim.Play("Newspaper01");
        newspaperObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        newspaperObject.GetComponent<SpriteRenderer>().sprite = endNewspaperSprite[ending];
        end = true;
            
    }
    public void Update()
    {
        if(Letter.letterId > 7)
        {
            GameObject.FindGameObjectWithTag("Choice01").GetComponent<Button>().interactable = false;
            GameObject.FindGameObjectWithTag("Choice02").GetComponent<Button>().interactable = false;
            GameObject.FindGameObjectWithTag("Choice03").GetComponent<Button>().interactable = false;
        }
        if(Letter.letterId > 6)
        {
            if(totalWeightage < 16)
            {
                GameObject.FindGameObjectWithTag("Choice03").GetComponent<Button>().interactable = false;
            }
        }
        
    if (Letter.letterId > 7  && ! end && showEnd)
        {
            if(totalWeightage >= 16)
            {
                //Good Ending
                EndGame(2);
            }
            else if(totalWeightage >= 12)
            {
                //Bad Ending 2
                EndGame(1);
            }
            else
            {
                //Bad Ending 
                EndGame(0);
            }
            
        }
    }
}
