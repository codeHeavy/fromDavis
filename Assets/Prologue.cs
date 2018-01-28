using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour {

    public TextMesh textMesh;
    public List<string> introText;
    public int currentIndex = 0;
    float TotalTime = 0.0F;

	// Use this for initialization
	void Start () {
        textMesh.color = Color.black;
    }

    void FadeOutText()
    {
        var newColor = Color.Lerp(textMesh.color, Color.black, 0.1f);
        textMesh.color = newColor;
    }

    void FadeInText()
    {
        var newColor = Color.Lerp(textMesh.color, Color.white, 0.1f);
        textMesh.color = newColor;
    }

    // Update is called once per frame
    void Update () {
        TotalTime += Time.deltaTime;
        UpdateState();
        if(currentIndex == introText.Count-1)
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    void UpdateState()
    {
        if (TotalTime > 5F)
        {
            if (currentIndex + 1 < introText.Count)
            {
                currentIndex++;
                TotalTime = 0F;
            }
            else
            {
                TotalTime = 5F;
            }            
        }
        else
        {
            if(TotalTime>0F && TotalTime < 1F)
            {
                textMesh.text = introText[currentIndex];
                FadeInText();
            }
            else if (TotalTime > 4F)
            {
                FadeOutText();
            }
        }
    }
}
