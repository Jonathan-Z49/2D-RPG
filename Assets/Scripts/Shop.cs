using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    private Movement player;
    private GameObject potionMakerShop;
    private GameObject weaponsmithShop;
    private GameObject activeShop;
    private Animator animControllerMessageSuccess;
    private Animator animControllerMessageFailed;
    private TextMeshProUGUI textSuccessMessage;
    private int costOfItem;
    private Text itemName;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Movement>();
        animControllerMessageSuccess = transform.Find("Purchased message").GetComponent<Animator>();
        animControllerMessageFailed = transform.Find("Unsuccessful message").GetComponent<Animator>();
        textSuccessMessage = transform.Find("Purchased message").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        Debug.Log(textSuccessMessage);
        potionMakerShop = transform.GetChild(0).gameObject;
        weaponsmithShop = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showShopUI(string NPC) {
        if (NPC == "Potion maker")
        {
            potionMakerShop.SetActive(true);   
            activeShop = potionMakerShop; 
        } else {
            weaponsmithShop.SetActive(true);
            activeShop = weaponsmithShop;
        }
    }
    public void hideShopUI() {
        if(activeShop == null){

        }
        else{
        activeShop.SetActive(false);
        }
        
    }

    public void clickToBuy(){

        if (activeShop.activeSelf)
        {
            itemName = activeShop.transform.Find("Item1/item container/item name").GetComponent<Text>();
            animControllerMessageFailed.ResetTrigger("fadeIn");
            animControllerMessageFailed.Rebind();
            animControllerMessageFailed.Update(0f);
            animControllerMessageSuccess.ResetTrigger("fadeIn");
            animControllerMessageSuccess.Rebind();
            animControllerMessageSuccess.Update(0f);
            costOfItem = int.Parse(activeShop.transform.Find("Item1/item container/item cost").GetComponent<Text>().text);
            if (player.coins >= costOfItem)
            {
                animControllerMessageSuccess.SetTrigger("fadeIn");
                textSuccessMessage.text = "You have purchased 1 " + itemName.text;
                player.subtractCoins(costOfItem);
            } else
            {
                animControllerMessageFailed.SetTrigger("fadeIn");
            }
        }
    }
    
}
