using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static int coins = 5;
    public static int staminaPotCount = 0;
    public static int healthPotCount = 0;
    public static int arrowCount = 0;
     
     void Awake()
     {
         DontDestroyOnLoad(this);
     }
}
