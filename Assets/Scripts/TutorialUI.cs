using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] keys;
    public GameObject ImageUI;
    public GameObject instructions;
    public GameObject coinCounterUI;
    public GameObject Enemy;
    public GameObject player;
    private Movement playerScript;

    private Image img;
    private TextMeshProUGUI text;
    private Text coinText;
    private bool spawned = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Movement>();
        coinText = coinCounterUI.GetComponent<Text>();
        img = ImageUI.GetComponent<Image>();
        text = instructions.GetComponent<TextMeshProUGUI>();
        text.text = "Press the \n\n\n Key to move Forward";
        img.sprite = keys[0];
        Enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        coinText.text = "X " + playerScript.coins.ToString();
        //Debug.Log(playerScript.coins);

        if (Input.GetKeyDown(KeyCode.W) && img.sprite == keys[0])
        {
            text.text = "Press the \n\n\n Key to move Down";
            img.sprite = keys[1];
        }
        if (Input.GetKeyDown(KeyCode.S) && img.sprite == keys[1])
        {
            text.text = "Press the \n\n\n Key to move Right";
            img.sprite = keys[2];
        }
        if (Input.GetKeyDown(KeyCode.D) && img.sprite == keys[2])
        {
            text.text = "Press the \n\n\n Key to move Left";
            img.sprite = keys[3];
        }
        if (Input.GetKeyDown(KeyCode.A) && img.sprite == keys[3])
        {
            text.text = "";
            ImageUI.SetActive(false);
        }

        if (text.text == "")
        {
            Enemy.SetActive(true);
            text.text = "Press the \n\n\n Key to Attack the enemy";
            img.sprite = keys[4];
            ImageUI.SetActive(true);
            spawned = true;
        }

        if(spawned && Enemy == null){
            ImageUI.SetActive(false);
            instructions.SetActive(false);
        }

    }

}

