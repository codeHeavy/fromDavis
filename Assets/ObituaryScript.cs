using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObituaryScript : MonoBehaviour {

    public List<Sprite> Obituaries;
    Animator anim;
    bool clicked = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Obituaries.Count != 0)
        gameObject.GetComponent<SpriteRenderer>().sprite = Obituaries[1];
	}

    public void OnNewpaperClick()
    {
        if (!clicked)
        {
            clicked = true;
            anim.Play("Newspaper01");
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else if (clicked)
        {
            clicked = false;
            anim.Play("Newspaper01_reverse");
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }
}
