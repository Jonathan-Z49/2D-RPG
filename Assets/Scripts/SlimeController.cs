using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    public int health = 3;
    private float timer = 1.2f;     //timer for death animation, need to find better way of doing this
    public GameObject CoinPrefab; 
    public Animator animator;


    public void takeDamage(int i)
    {
        animator.SetTrigger("Damaged");
        health -= i;
        //Debug.Log("took damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {   
            animator.SetBool("Dead", true);
            timer = timer - Time.deltaTime;
            if(timer <= 0){
                Destroy(gameObject);
                for(int i = 3; i > 0; i--){
                    Instantiate(CoinPrefab, transform.position, Quaternion.identity);
                }
            }
            //Debug.Log("died");
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Arrow")
        {
            takeDamage(1);
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
       
    }

    public int getHealth()
    {
        return health;
    }
}
