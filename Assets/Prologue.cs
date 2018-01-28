using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour {

    public TextMesh textMesh;
    public List<string> introText;
    public int currentIndex = 0;
    public int currentImageIndex = 0;
    float TotalTime = 0.0F;
    float TotalTimeImage = 0.0F;
    public List<Sprite> sprites;
    public GameObject Background;
    SpriteRenderer spRenderer;
    Color originalColor;
	// Use this for initialization
	void Start () {
        textMesh.color = Color.black;
        spRenderer = Background.GetComponent<SpriteRenderer>();
        originalColor = spRenderer.color;
    }

    void FadeOutText()
    {
        Color c = Color.black;
        c.a = 0;
        var newColor = Color.Lerp(textMesh.color, c, 0.1f);
        textMesh.color = newColor;
    }

    void FadeInText()
    {
        var newColor = Color.Lerp(textMesh.color, Color.white, 0.1f);
        textMesh.color = newColor;
    }

    void FadeInImage()
    {
        var c = spRenderer.color;
        spRenderer.color = Color.Lerp(spRenderer.color, originalColor, 0.1f);
    }

    void FadeOutImage()
    {
        var c = spRenderer.color;
        c.a = 0;
        spRenderer.color = Color.Lerp(spRenderer.color, c, 0.1f);
    }

    // Update is called once per frame
    void Update () {
        TotalTime += Time.deltaTime;
        TotalTimeImage += Time.deltaTime;
        UpdateState();
        UpdateImage();
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

    void UpdateImage()
    {
        if (TotalTimeImage > 10F)
        {
            if (currentImageIndex + 1 < sprites.Count)
            {
                currentImageIndex++;
                TotalTimeImage = 0F;
            }
            else
            {
                TotalTimeImage = 10F;
            }
        }
        else
        {
            if (TotalTimeImage > 0F && TotalTimeImage < 1F)
            {
                spRenderer.sprite = sprites[currentImageIndex];
                FadeInImage();
            }
            else if (TotalTimeImage > 8F)
            {
                FadeOutImage();
            }
        }
    }


}
