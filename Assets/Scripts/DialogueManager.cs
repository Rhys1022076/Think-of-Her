using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //add TMP objects into inspector fields for NPC/interaction name and dialogue text
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject player;
    public Animator animator;
    public Animator flashAnim;
    public GameObject reaction;

    public AudioSource sighAudio;
    public AudioSource pixAudio;
    public AudioClip sighClip;
    public AudioClip pixClip;
    
    //creates a queue of sentences to be displayed
    private Queue<string> sentences;

    void Start()
    {
        //initiate queue
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //triggers animation for dialogue box appearing
        animator.SetBool("IsOpen", true);

        //freeze player position
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        //replace name field with NPC name and clear sentence queue
        nameText.text = dialogue.name;
        sentences.Clear();

        //add sentences from triggered NPC/interaction to the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //void Update()
    //{
    //    //press space bar to advance dialogue
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DisplayNextSentence();
    //    }
    //}

    
    public void DisplayNextSentence()
    {
        //if no sentences remain end dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //remove current sentence from the queue, stop typing...
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        //begin typing next sentence in queue
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        //replace dialogue field with sentence text
        dialogueText.text = "";
        //add letters one by one from current sentence, for typing effect
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        //trigger animation for dialogue box disappearing
        animator.SetBool("IsOpen", false);


        if (SceneManager.GetActiveScene().name == "From Work")
        {
            //reenable player movement
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            StopAllCoroutines();
            FindObjectOfType<PostProcessEffects>().StartClosing();

        }
        else if (SceneManager.GetActiveScene().name == "Home")
		{
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            flashAnim.Play("GoldFlash");
            sighAudio.PlayOneShot(sighClip);
            pixAudio.PlayOneShot(pixClip);

            StopAllCoroutines();
            FindObjectOfType<PostProcessEffects>().StartBloom();
        }
        else
        {
            //set reaction canvas active
            reaction.SetActive(true);
        }
    }
}
