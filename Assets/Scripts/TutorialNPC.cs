using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNPC : MonoBehaviour
{

    public GameObject tutorialui;
    public GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideDialogue()
    {
        dialogueBox.SetActive(false);
        tutorialui.SetActive(true);
    }
}
