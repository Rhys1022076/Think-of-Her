using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugTrigger : MonoBehaviour
{
    public GameObject player;
    public Animator flashAnim;

    public AudioSource sighAudio;
    public AudioSource pixAudio;
    public AudioClip sighClip;
    public AudioClip pixClip;


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
		{
            StartCoroutine(Hug());
        }
    }

    IEnumerator Hug()
	{
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        flashAnim.Play("GoldFlash");
        sighAudio.PlayOneShot(sighClip);
        pixAudio.PlayOneShot(pixClip);
        FindObjectOfType<PostProcessEffects>().StartBloom();

        yield return new WaitForSeconds(1f);
    }
}
