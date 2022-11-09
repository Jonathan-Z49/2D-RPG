using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showNPCTalkButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NPC_InstructionText;
    private GameObject player;
    private GameObject npc;
    public Dialogue dialogue;
    public string message;
    public string questStartMessage;
    public string questCompleteMessage;
    private float distanceToPlayer;
    public Movement playerScript;
    public GameObject questItem;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        npc = transform.parent.gameObject;
        playerScript = player.transform.GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (NPC_InstructionText.activeSelf && distanceToPlayer < 3.0f)
        {
            if (Input.GetKeyDown("space"))
            {
                NPC_InstructionText.SetActive(false);
                dialogue.showDialogueBox();
                dialogue.setNameOfNPC(transform.parent.name);
                StartCoroutine(dialogue.Typing(message));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        NPC_InstructionText.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other) {
        NPC_InstructionText.SetActive(false);
        dialogue.hideDialogue();
    }

    public void showQuestMessage()
    {
        if(playerScript.checkActiveStatus() == true && playerScript.checkQuestItem() == true)
        {
            playerScript.addCoins(10);
            playerScript.deactivateQuest();
            playerScript.removeQuestItem();
            dialogue.dialogueToSay = " ";
            dialogue.dialogueTextUI.text = "";
            StartCoroutine(dialogue.Typing(questCompleteMessage));
        }
        else
        {
            questItem.SetActive(true);
            playerScript.activateQuest();
            dialogue.dialogueToSay = " ";
            dialogue.dialogueTextUI.text = "";
            StartCoroutine(dialogue.Typing(questStartMessage));
        }
        
    }
}
