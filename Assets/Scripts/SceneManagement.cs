using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene(1);
    }

    public void QuitApp() {
        Application.Quit();
    }

    public void OpenSettings() {
        SceneManager.LoadScene(3);
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
}
