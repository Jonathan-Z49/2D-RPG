using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private GameObject player;
    public MonoBehaviour npc = null;
    private float attackCooldown = 0.0f;
    private float animCooldown = .20f;
    public int damage = 1;
    private bool ableAttack = false;
    private bool npcFlag = false;
    
    public GameObject[] Enemys;        //fixed, dont have to manually select enemy anymore.
    public List<GameObject> EnemysInTrigger;

    private Rigidbody2D rb;
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);
    Vector3 up = new Vector3(0, 1, 0);
    Vector3 down = new Vector3(0, -1, 0);

    public StaminaBar staminaBar;
    public GameObject bow;
    public GameObject dialogue = null;

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
            foreach(var enemy in Enemys)
            {
                if(EnemysInTrigger.Contains(enemy))
                {
                    enemy.GetComponent<SlimeController>().takeDamage(damage);
                }
            }
        }
    }

    void Start()
    {
        player = transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        transform.position = transform.parent.position + up;
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        attackCooldown = attackCooldown - Time.deltaTime;
        animCooldown -= Time.deltaTime;
        if(animCooldown <= 0)
        {
            player.GetComponent<Animator>().SetBool("isAttacking", false);
        }
        if (Input.GetAxisRaw("Horizontal") < 0 )//a
        {
            transform.position = transform.parent.position + left;
            transform.localScale = new Vector3(1.5f, 2, 0);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)//d
        {
            transform.position = transform.parent.position + right;
            transform.localScale = new Vector3(1.5f, 2, 0);
        }
        if (Input.GetAxisRaw("Vertical") < 0)//s
        {
            transform.position = transform.parent.position + down;
            transform.localScale = new Vector3(2, 1.75f, 0);
        }
        if (Input.GetAxisRaw("Vertical") > 0)//w
        {
            transform.position = transform.parent.position + up;
            transform.localScale = new Vector3(2, 1.75f, 0);
        }
        if(Input.GetMouseButtonDown(0) && !bow.activeSelf && (dialogue == null || !dialogue.activeSelf) )
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
            //Enemy = Other.transform.GetComponent<SlimeController>(); //gets specific collided enemy's script.
            EnemysInTrigger.Add(Other.gameObject);
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
            EnemysInTrigger.Remove(Other.gameObject);
        }
    }


}
