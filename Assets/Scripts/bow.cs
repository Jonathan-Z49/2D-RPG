using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
private Vector2 dir;
    private Vector2 mousePosition;
    private Vector2 bowPosition;
    private GameObject player;
    private Movement playerStats;
    private SpriteRenderer bowSprite;
    public float arrow_speed = 10.0f;
    public GameObject arrow;
    public GameObject arrowClone;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<Movement>();
        bowSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = player.transform.position;
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10.0f));
            bowPosition = transform.position;
            dir = mousePosition - (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10.0f));
            transform.right = dir * -1;

        if (Input.GetMouseButtonDown(0) && gameObject.activeSelf && playerStats.arrowCount > 0)
            {
                GameObject arrowInstantiated = Instantiate(arrowClone, arrow.transform.position, arrow.transform.rotation);
                arrowInstantiated.GetComponent<Rigidbody2D>().AddForce(transform.right * arrow_speed);
                Physics2D.IgnoreCollision(player.gameObject.GetComponent<BoxCollider2D>(), arrowInstantiated.gameObject.GetComponent<Collider2D>(), true);
                playerStats.useArrow();
            }
        }
    }
}
