using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject player;
    private float RandSpeed;
    private float _SPEED = 20f;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    
        RandSpeed = Random.Range(200f,400f);
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Random.onUnitSphere * RandSpeed);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        var dif = player.transform.position - rb.transform.position;
        rb.AddForce(dif * _SPEED * Time.deltaTime);
        _SPEED += 10f;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            player.GetComponent<Movement>().addCoins(Random.Range(1, 5));
            Destroy(gameObject);
        }
    }
}
