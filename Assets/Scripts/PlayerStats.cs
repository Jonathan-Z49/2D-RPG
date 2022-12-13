using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static int coins = 5;
    public static int staminaPotCount = 0;
    public static int healthPotCount = 0;
    public static int arrowCount = 0;
    public static int health = 10;
    public static bool questActive = false;
    public static bool questItemHeld = false;
    public static bool firstEntrance = true;
     
     void Awake()
     {
         DontDestroyOnLoad(this);
     }
}
