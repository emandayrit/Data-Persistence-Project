using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public MenuButtons menuButtons;

    public void GameStart()
    {
        if (menuButtons.inputField.text.Length == 0)
        {
            menuButtons.warningText.SetActive(true);
        }
        else
        {
            GameController.PLAYERNAME = menuButtons.inputText.text;
            SceneManager.LoadScene("main");
        }
    }

    public void GameExit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
