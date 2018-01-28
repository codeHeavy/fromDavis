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
    bool clickable = true;
    private void Start()
    {
        textObject = GameObject.FindGameObjectWithTag("LetterText").GetComponent<Text>();
    }

    public void OnButtonClick()
    {
        if (clickable)
        {
            string selectedOption = gameObject.GetComponentInChildren<Text>().text;
            fullText = selectedOption;
            StartCoroutine(OutputText());
            Letter.currentChoice = thisChoice.choiceNumber;
            clickable = false;
        }
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
        if (partialText.Equals(fullText))
        {
            clickable = true;
        }
    }
}
