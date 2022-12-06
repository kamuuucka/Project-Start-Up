using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject dialogueButton;

    public Dialogue dialogue;

    private void Awake()
    {
        dialogueBox.SetActive(false);

    }

    public void TriggerDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueButton.SetActive(false);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
