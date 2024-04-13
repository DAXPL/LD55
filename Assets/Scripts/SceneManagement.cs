using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene(0);
    }

    public void QuitApp() {
        Application.Quit();
    }
}
