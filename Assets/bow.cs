using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{

    public Vector2 dir;
    private Vector2 mousePosition;
    private Vector2 bowPosition;
    private GameObject player;
    private SpriteRenderer bowSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bowSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10.0f));
        bowPosition = transform.position;
        dir = mousePosition - (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10.0f));
        transform.right = dir * -1;
    }
}
