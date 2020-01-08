using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{

    public Dialogue dialogue;

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float typingSpeed;

    public GameObject canvasDialogue;
    public GameObject canvasTimer;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue();
        gameObject.GetComponent<movement>().enabled = false;
        canvasTimer.SetActive(false);
    }

    void StartDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentencesList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentences();   
    }

    void DisplayNextSentences()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && displayText.text == activeSentence)
        {
            if(sentences.Count == 0)
            {
                gameObject.GetComponent<movement>().enabled = true;
                canvasTimer.SetActive(true);
                canvasDialogue.SetActive(false);
            }

            DisplayNextSentences();
        }

        
    }
}
