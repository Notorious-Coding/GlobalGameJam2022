using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Demo");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Demo");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
