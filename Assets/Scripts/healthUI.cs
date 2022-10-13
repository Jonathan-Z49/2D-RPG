using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healthPanel;
    public GameObject player;
    private SlimeController enemy;
    private Slider healthSlider;
    private float initialHealth;
    void Start()
    {
        enemy = player.GetComponent<SlimeController>();
        healthSlider = healthPanel.GetComponent<Slider>();
        initialHealth = enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = enemy.health / initialHealth;
    }
}
