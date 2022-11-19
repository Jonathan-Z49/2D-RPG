using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private GameObject player;
    public MonoBehaviour npc;
    private float attackCooldown = 0.0f;
    private float animCooldown = .20f;
    public int damage = 1;
    private bool ableAttack = false;
    private bool npcFlag = false;
    
    private MonoBehaviour Enemy;        //fixed, dont have to manually select enemy anymore.

    private Rigidbody2D rb;
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);
    Vector3 down = new Vector3(0, -1, 0);

    public StaminaBar staminaBar;
    public GameObject bow;
    public GameObject dialogue;

    // Start is called before the first frame update

    void Attack()
    {   
        player.GetComponent<Movement>().setSpeed(0f);
        player.GetComponent<Animator>().SetBool("isAttacking", true);
        animCooldown = .20f;
        staminaBar.useStamina(1);
        player.GetComponent<Movement>().setStamTimer();
        if(ableAttack)
        {
            //Debug.Log("Attacked");
            Enemy.GetComponent<SlimeController>().takeDamage(damage); 
        }
    }

    void Start()
    {
        player = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        transform.position = transform.parent.position + up;
       
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown = attackCooldown - Time.deltaTime;
        animCooldown -= Time.deltaTime;
        if(animCooldown <= 0)
        {
            player.GetComponent<Animator>().SetBool("isAttacking", false);
        }
        if (Input.GetKeyDown("w"))
        {
            transform.position = transform.parent.position + up;
        }
        if (Input.GetKeyDown("a"))
        {
            transform.position = transform.parent.position + left;
        }
        if (Input.GetKeyDown("s"))
        {
            transform.position = transform.parent.position + down;
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position = transform.parent.position + right;
        }
        if(Input.GetMouseButtonDown(0) && !bow.activeSelf && !dialogue.activeSelf)
        {
            if(attackCooldown <= 0.0f && staminaBar.checkStaminaValue() > 0f)
            {
                Attack();
                attackCooldown = .75f;
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "NPC")
        {
           npcFlag = true; 
            npc = Other.transform.GetComponent<TutorialNPC>(); //gets specific collided enemy's script.
        }

        if(Other.tag == "Enemy")
        {
            ableAttack = true;
            Enemy = Other.transform.GetComponent<SlimeController>(); //gets specific collided enemy's script.
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.tag == "NPC")
        {
            npcFlag = false;
        }

        if(Other.tag == "Enemy")
        {
            ableAttack = false;
        }
    }


}
