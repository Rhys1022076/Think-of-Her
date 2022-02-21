using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject canvasRestart;
    public GameObject canvasHelp;

    public void StartGame()
    {        
        //loads level one
        SceneManager.LoadScene("To Work");
    }

    public void Help()
	{
        //set instructions canvas to active
        canvasHelp.SetActive(true);
	}

    //public void QuitGame()
    //{
    //    Debug.Log("Bye");
    //    Application.Quit();
    //}

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            //return to menu
            SceneManager.LoadScene("Menu");
        }
    }

    public void Restart()
	{
        Debug.Log("restarting");
        StartCoroutine(Overwhelmed());
	}

    public IEnumerator Overwhelmed()
	{
        canvasRestart.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvasRestart.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
