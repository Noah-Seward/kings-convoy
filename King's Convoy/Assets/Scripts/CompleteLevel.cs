using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "Menu Scene";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void Continue()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
