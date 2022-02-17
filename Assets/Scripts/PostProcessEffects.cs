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

    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = 0.15f;
    }

    public void IncreaseIntensity()
    {
        vignette.intensity.value += 0.05f;  

        StopAllCoroutines();
        StartCoroutine(ResetUI());
    }

    public void DecreaseIntensity()
    {
        vignette.intensity.value -= 0.05f;

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
