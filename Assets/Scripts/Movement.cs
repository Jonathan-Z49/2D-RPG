using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int currentHealth;
    private int maxHealth = 10;
    public HealthBar healthBar;
    private float maxStamina = 5f;
    public StaminaBar staminaBar;
    private float stamRecovery = 1f;
    private float stamTimer = 2.5f;
    public int coins;
    public int staminaPotCount = 0;
    public int healthPotCount = 0;
    public int arrowCount = 0;
    private float _SPEED;
    //private float _DIRECTION_X = 0f;
    //private float _DIRECTION_Y = 0f;
    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private float attackCounter;
    private bool isAttacking;
    Vector2 movement;
    private bool questActive = false;
    private bool questItemHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        staminaBar.setMaxStamina(maxStamina);
        currentHealth = maxHealth;
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("LastVmove", 1);
    }

    // Update is called once per frame
    void Update()
    {
        //playerRigidBody.MovePosition(playerRigidBody.position + movement * _SPEED * Time.deltaTime);
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical"); 
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat(("LastHmove"), Input.GetAxisRaw("Horizontal"));
            animator.SetFloat(("LastVmove"), Input.GetAxisRaw("Vertical"));
        }

        //health bar debugging
        if(Input.GetKeyDown("i"))
        {
            this.takeDamage(1);
        }
        if(Input.GetKeyDown("o"))
        {
            increaseMaxHealth();
        }

        if(Input.GetKey(KeyCode.LeftShift) && staminaBar.checkStaminaValue() > 0)
        {
            if(animator.GetFloat("Horizontal") != 0 || animator.GetFloat("Vertical") != 0)
            {
                setStamTimer();
                _SPEED = 11.0f;
                staminaBar.useStamina(Time.deltaTime);  
            }
        }
        else
        {
            _SPEED = 7.0f;
        }
        
        stamTimer -= Time.deltaTime;
        if(stamTimer <= 0)
        {
            staminaBar.recoverStamina(stamRecovery);
        }
    }

    void FixedUpdate()
    {
      playerRigidBody.MovePosition(playerRigidBody.position + movement * _SPEED * Time.deltaTime);
    }


    public void setSpeed(float s)
    {
        _SPEED = s;
    }

    public void addCoins(int amount)
    {
        coins += amount;
        //Debug.Log("added: " + amount + ", total: " + coins);
    }
    public void subtractCoins(int amount)
    {
        coins -= amount;
        //Debug.Log("added: " + amount + ", total: " + coins);
    }

    public void takeDamage(int dam)
    {
        currentHealth -= dam;
        healthBar.setHealth(currentHealth);
    }

    public void addHealthPot() {
        healthPotCount++;
    }

    public void addStaminaPot() {
        staminaPotCount++;
    }

    public void useStaminaPot() {
        if (staminaPotCount > 0)
        {
            staminaPotCount--;
            staminaBar.setMaxStamina(maxStamina);
        }
    }

    public void addArrows() {
        arrowCount++;
    }

    public void useArrow() {
        if (arrowCount > 0)
        {
            arrowCount--;
        }
    }

    public void increaseMaxHealth()
    {
        if (healthPotCount > 0)
        {
            healthPotCount--;
            maxHealth += 1;
            healthBar.setMaxHealth(maxHealth);
            currentHealth = maxHealth;
            healthBar.setHealth(currentHealth);
        }
    }

    public void activateQuest()
    {
        questActive = true;
    }

    public void deactivateQuest()
    {
        questActive = false;
    }

    public bool checkActiveStatus()
    {
        if(questActive == true)
        {
            return(true);
        }
        else{return(false);}
    }

    public void getQuestItem()
    {
        questItemHeld = true;
    }

    public void removeQuestItem()
    {
        questItemHeld = false;
    }

    public bool checkQuestItem()
    {
        if(questItemHeld == true)
        {
            return(true);
        }
        else{return(false);}
    }

    public void setStamTimer()
    {
        stamTimer = 2f;
    }

}
