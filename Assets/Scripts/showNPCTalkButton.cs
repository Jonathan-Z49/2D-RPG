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
    private float distanceToPlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        npc = transform.parent.gameObject;
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
}
