using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject canvasTransition;
    public GameObject player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Work")
		{
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            StopAllCoroutines();
            StartCoroutine(Transition());
		}
        else if (collision.gameObject.tag == "Player")
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Transition()
	{
        canvasTransition.SetActive(true);
        anim.Play("Transition");
        yield return new WaitForSeconds(5f);
        NextLevel();
	}
}
