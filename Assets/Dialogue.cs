using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string dialogueToSay;
    public Text dialogueTextUI;
    public GameObject contButton;
    public GameObject dialogueBox;
    private string text;
    public float wordSpeed;
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueTextUI.text == dialogueToSay)
        {
            contButton.SetActive(true);
        }
    }

    public void hideDialogue()
    {
        dialogueBox.SetActive(false);
        zeroText();
    }
    public void showDialogueBox()
    {
        dialogueBox.SetActive(true);
    }
    public void Typing() //types out each individual letter
    {
        for (int i = 0; i < dialogueToSay.Length; i++) 
        {
           dialogueTextUI.text += dialogueToSay[i];
        }
    }

    public void zeroText() //empties the dialogue box
    {
        dialogueTextUI.text = "";
        dialogueBox.SetActive(false);
    }
}
