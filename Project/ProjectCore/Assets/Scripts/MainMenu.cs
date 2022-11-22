using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetInfo() {
        GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("InfoCanvas").GetComponent<Canvas>().enabled = true;
    }

    public void Return() {
        GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("InfoCanvas").GetComponent<Canvas>().enabled = false;
    }

    public void Quit() {
        Application.Quit();
    }
}
