using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene("Cut_Scene");
    }
    public void QuitGame ()
    {
        //Application.Quit();
        //Debug.Break();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
