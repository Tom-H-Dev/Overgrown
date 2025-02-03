using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Checks if you are playing in the editor then goes out of playmode else closes the application
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    /// <summary>
    /// Go to a different scene
    /// </summary>
    /// <param name="SceneName"></param>The name of the scene you want to load in to
    public void ToScene(string SceneName) => SceneManager.LoadScene(SceneName);
}
