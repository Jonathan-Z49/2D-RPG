using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignQuestItem : MonoBehaviour
{

    public GameObject[] Enemys;
    public Movement playerScript;
    private int l = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = l; i > 0; i--)
        {
            int j = Random.Range(0, Enemys.Length);
            Debug.Log(j);
            if(playerScript.checkActiveStatus() == true)
            {
                Enemys[j].GetComponent<RangedSlimeMovement>().assignQuestItem();
            }
            l = 0;
        }
    }
}
