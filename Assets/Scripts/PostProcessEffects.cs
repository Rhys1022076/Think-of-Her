using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PostProcessEffects : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vignette;
    private Bloom bloom;

    public GameObject reaction;
    public GameObject player;
    public UI ui;
    
    void Start()
    {
        volume.profile.TryGetSettings(out bloom);
        bloom.intensity.value = 0f;
        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0.2f;
        
        if (SceneManager.GetActiveScene().name == "Home")
		{
            vignette.intensity.value = 0f;
            bloom.intensity.value = 3f;
        }
    }

	private void Update()
	{
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //vignette.intensity.value += 0.1f;
        //Debug.Log("intensifying");
        //}

        if (vignette.intensity.value >= 0.6f && (SceneManager.GetActiveScene().name != "From Work"))
        {
            //Debug.Log("Searching");
            FindObjectOfType<UI>().Restart();
        }
        else if (vignette.intensity.value >= 1f && (SceneManager.GetActiveScene().name == "From Work"))
        {
            FindObjectOfType<UI>().Restart();
        }
    }

	public void IncreaseIntensity()
    {
        vignette.intensity.value += 0.1f;

        StopAllCoroutines();
        StartCoroutine(ResetUI());
    }

    public void DecreaseIntensity()
    {
        vignette.intensity.value -= 0.1f;

        StopAllCoroutines();
        StartCoroutine(ResetUI());
    }

    IEnumerator ResetUI()
    {
        reaction.SetActive(false);
        yield return new WaitForSeconds (0.1f);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    public void StartClosing()
	{
        StartCoroutine(ClosingIn());
	}

    IEnumerator ClosingIn()
	{
        Debug.Log("get home" + vignette.intensity.value);
        vignette.intensity.value += 0.02f;
        yield return new WaitForSeconds(0.5f);
        InvokeRepeating("StartClosing", 0, 60);
	}

    public void StartBloom()
	{
        StartCoroutine(BloomEffect());
	}

    IEnumerator BloomEffect()
	{
        Debug.Log("Blooming");
        bloom.intensity.value += 2f;
        yield return new WaitForSeconds(2f);
        bloom.intensity.value -= 2f;
	}
}
