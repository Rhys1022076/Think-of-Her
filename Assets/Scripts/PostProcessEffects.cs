using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessEffects : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette vignette;

    public GameObject reaction;
    public GameObject player;
    public UI ui;
    
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0.2f;
    }

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.C))
        {
            vignette.intensity.value += 0.1f;
            Debug.Log("intensifying");
        }

        if (vignette.intensity.value >= 0.6f)
        {
            Debug.Log("Searching");
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
}
