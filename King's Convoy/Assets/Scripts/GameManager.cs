using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool GameWon;

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    private void Start()
    {
        GameIsOver = false;
        GameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (GameWon)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (PlayerStats.Rounds >= 12)
        {
            WinLevel();
        }
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameWon = true;

        gameWonUI.SetActive(true);
    }
}
