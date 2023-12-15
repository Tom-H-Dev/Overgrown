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

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToScene(string SceneName) => SceneManager.LoadScene(SceneName);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ToScene("Alpha");
        }
    }

}
