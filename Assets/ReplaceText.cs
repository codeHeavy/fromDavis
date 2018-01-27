using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplaceText : MonoBehaviour {

    Text textObject;
    public Choice thisChoice = new Choice();

    public float delay = 0.1f;
    private string partialText;
    private string fullText;
    private void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("LetterText").GetComponent<Text>();
        //gameObject.GetComponentInChildren<Text>().text = thisChoice.sentence;
    }

    public void OnButtonClick()
    {
        string selectedOption = gameObject.GetComponentInChildren<Text>().text;
        //textObject.text = selectedOption;
        fullText = selectedOption;
        StartCoroutine(OutputText());
        Letter.currentChoice = thisChoice.choiceNumber;
    }

    public void ChangeChoices()
    {
        gameObject.GetComponentInChildren<Text>().text = thisChoice.sentence;
    }
    private void Update()
    {
        gameObject.GetComponentInChildren<Text>().text = thisChoice.sentence;
    }
    IEnumerator OutputText()
    {
        for (int i = 0;i <= fullText.Length; i++)
        {
            partialText = fullText.Substring(0, i);
            textObject.text = partialText;
            yield return new WaitForSeconds(delay);
        }
    }
}
