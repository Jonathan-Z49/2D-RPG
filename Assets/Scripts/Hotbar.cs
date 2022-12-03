using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hotbar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healthTile;
    public GameObject staminaTile;
    public GameObject bowTile;
    private Button healthButton;
    private Text healthText;
    private Button staminaButton;
    private Text staminaText;
    private Button bowButton;
    private Text arrowText;
    public GameObject Bow;
    private EventSystem eventSystem = EventSystem.current;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        healthButton = healthTile.transform.GetChild(0).GetComponent<Button>();
        staminaButton = staminaTile.transform.GetChild(0).GetComponent<Button>();
        bowButton = bowTile.transform.GetChild(0).GetComponent<Button>();
        healthText = healthTile.transform.GetChild(1).GetComponent<Text>();
        staminaText = staminaTile.transform.GetChild(1).GetComponent<Text>();
        arrowText = bowTile.transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = PlayerStats.healthPotCount.ToString() + "x";
        staminaText.text = PlayerStats.staminaPotCount.ToString() + "x";
        arrowText.text = PlayerStats.arrowCount.ToString() + "x";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            simulateClick(healthButton);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            simulateClick(staminaButton);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            simulateClick(bowButton);
            if (Bow.activeSelf)
            {
                Bow.SetActive(false);
            } else {
                Bow.SetActive(true);
            }
        }
    }

    public void simulateClick(Button myButton) {
        ExecuteEvents.Execute(myButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
    }
}

