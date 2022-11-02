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
    private Dialogue dialogue;
    private float distanceToPlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        npc = transform.parent.gameObject;
        dialogue = npc.gameObject.GetComponent<Dialogue>();
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());
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
                StartCoroutine(dialogue.Typing());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(this);
        NPC_InstructionText.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other) {
        NPC_InstructionText.SetActive(false);
        dialogue.hideDialogue();
    }
}
