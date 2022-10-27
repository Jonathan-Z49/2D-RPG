using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialNPC : MonoBehaviour
{

    public GameObject tutorialui;
    public GameObject dialogueBox;
    public GameObject contButton;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(Typing()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialogueBox.SetActive(false);
        
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void nextLine()
    {
        contButton.SetActive(false);
        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();
        }
    }
    public void hideDialogue()
    {
        dialogueBox.SetActive(false);
        tutorialui.SetActive(true);
        nextLine();
    }
    public void showDialogue()
    {
        dialogueBox.SetActive(true);
        tutorialui.SetActive(false);
    }
    
}
