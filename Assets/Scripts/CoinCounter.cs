using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
       
        coinText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "X " + PlayerStats.coins.ToString();
    }
}
