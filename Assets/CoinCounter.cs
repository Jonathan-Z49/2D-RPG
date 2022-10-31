using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private Text coinText;
    private GameObject player;
    private Movement playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Movement>();
        coinText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "X " + playerScript.coins.ToString();
    }
}
