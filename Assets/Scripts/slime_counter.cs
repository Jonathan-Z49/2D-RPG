using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slime_counter : MonoBehaviour
{
    public Text slimeText;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        slimeText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        slimeText.text = "X " + enemies.Length.ToString();
    }
}
