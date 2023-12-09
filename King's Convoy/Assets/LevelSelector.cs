using UnityEngine;

public class LevelSelector : MonoBehaviour
{


    public void Select (string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
