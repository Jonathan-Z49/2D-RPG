using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public int currentHealth;
    private int maxHealth = PlayerStats.health;
    public HealthBar healthBar;
    public GameObject deathUI = null;
    private float maxStamina = 5f;
    public StaminaBar staminaBar;
    private float stamRecovery = 1f;
    private float stamTimer = 2.5f;
    public int coins = PlayerStats.coins;
    public int staminaPotCount = PlayerStats.staminaPotCount;
    public int healthPotCount = PlayerStats.healthPotCount;
    public int arrowCount = PlayerStats.arrowCount;
    private float _SPEED;
    //private float _DIRECTION_X = 0f;
    //private float _DIRECTION_Y = 0f;
    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private float attackCounter;
    private bool isAttacking;
    Vector2 movement;
    private bool questActive = PlayerStats.questActive;
    private bool questItemHeld = PlayerStats.questItemHeld;

    // Start is called before the first frame update
    void Start()
    {
        staminaBar.setMaxStamina(maxStamina);
        currentHealth = maxHealth;
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("LastVmove", 1);
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if(sceneName == "Town" && PlayerStats.firstEntrance == true)
        {
            transform.position = new Vector3(-18,-5, 0);
            PlayerStats.firstEntrance = false;
        }
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Debug.Log(PlayerStats.health);
        Debug.Log(PlayerStats.health > 0 && SceneManager.GetActiveScene().name != "Game" || deathUI == null);
      if (PlayerStats.health > 0 && SceneManager.GetActiveScene().name != "Game" || deathUI == null)
      {
        playerRigidBody.MovePosition(playerRigidBody.position + movement * _SPEED * Time.deltaTime);
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
      } else {
        deathUI.SetActive(true);
      }
    }

    public void onDeath() {
        Scene _scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_scene.name);
        PlayerStats.health = 10;
     }

    public void setSpeed(float s)
    {
        _SPEED = s;
    }

    public void addCoins(int amount)
    {
        PlayerStats.coins += amount;
        //Debug.Log("added: " + amount + ", total: " + coins);
    }
    public void subtractCoins(int amount)
    {
        PlayerStats.coins -= amount;
        if (PlayerStats.coins <= 0)
        {
            PlayerStats.coins = 0;
        }
        //Debug.Log("added: " + amount + ", total: " + coins);
    }

    public void takeDamage(int dam)
    {
        PlayerStats.health -= dam;
        healthBar.setHealth(PlayerStats.health);
    }

    public void addHealthPot() {
        if (PlayerStats.coins > 0)
        {
            PlayerStats.healthPotCount++;
        }
    }

    public void addStaminaPot() {
        if (PlayerStats.coins > 0)
        {
            PlayerStats.staminaPotCount++;
        }
    }

    public void useStaminaPot() {
        if (PlayerStats.staminaPotCount > 0)
        {
            PlayerStats.staminaPotCount--;
            staminaBar.setMaxStamina(maxStamina);
        }
    }

    public void addArrows() {
        if (PlayerStats.coins > 0)
        {
            PlayerStats.arrowCount++;            
        }
    }

    public void useArrow() {
        if (PlayerStats.arrowCount > 0)
        {
            PlayerStats.arrowCount--;
        }
    }

    public void increaseMaxHealth()
    {
        if (PlayerStats.healthPotCount > 0)
        {
            PlayerStats.healthPotCount--;
            PlayerStats.health += 1;
            healthBar.setMaxHealth(PlayerStats.health);
            currentHealth = PlayerStats.health;
            healthBar.setHealth(PlayerStats.health);
        }
    }

    public void activateQuest()
    {
        PlayerStats.questActive = true;
    }

    public void deactivateQuest()
    {
        PlayerStats.questActive = false;
    }

    public bool checkActiveStatus()
    {
        if(PlayerStats.questActive == true)
        {
            return(true);
        }
        else{return(false);}
    }

    public void getQuestItem()
    {
        PlayerStats.questItemHeld = true;
    }

    public void removeQuestItem()
    {
        PlayerStats.questItemHeld = false;
    }

    public bool checkQuestItem()
    {
        if(PlayerStats.questItemHeld == true)
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
