using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    void Start () {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Scenes/MainGame");
        }
	}
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Scenes/MainGame");
        }
    }



    /// <summary>
    /// Called when quit game button is pressed and quits application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
