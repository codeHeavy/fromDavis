using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void PlayClick()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void QuitClick()
    {
        Application.Quit();
    }
}
