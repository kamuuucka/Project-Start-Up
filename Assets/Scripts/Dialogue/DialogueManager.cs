using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text dialogueText;

    private Queue<string> sentences;

    //new
    public GameObject AudioObject;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        title.text = dialogue.name;

        if (sentences != null)
        {
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //new
        AudioObject.SetActive(true);
        AudioObject.SetActive(false);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //new
        AudioObject.SetActive(true);
        AudioObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
