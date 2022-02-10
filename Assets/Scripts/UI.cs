using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("To Work");
    }

    public void QuitGame()
    {
        Debug.Log("Bye");
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
