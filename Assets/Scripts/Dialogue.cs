using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public string dialogueToSay;
    public Text dialogueTextUI;
    public GameObject contButton;
    public GameObject shopButton;
    public GameObject questButton;
    public Shop shopUI;
    public Text nameOfNPC;
    private string text;
    public float wordSpeed;
    public Sprite[] npcImage;
    public GameObject dialogueImage;
    
    void Start()
    {
        shopUI = GameObject.Find("Shop UI").GetComponent<Shop>();
        dialogueImage = GameObject.Find("Dialogue Image");
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueTextUI.text == dialogueToSay)
        {
            contButton.SetActive(true);
        }
    }

    public void hideDialogue()
    {
        gameObject.SetActive(false);
        shopUI.hideShopUI();
        zeroText();
    }
    public void showDialogueBox()
    {
        gameObject.SetActive(true);
    }
    public void setNameOfNPC(string name) {
        nameOfNPC.text = name;
        if (name == "Weaponsmith")
        {
            questButton.SetActive(false);
            shopButton.SetActive(true);
            dialogueImage.GetComponent<Image>().sprite = npcImage[0];
        }
        else if(name == "Potion maker")
        {
            questButton.SetActive(false);
            shopButton.SetActive(true);
            dialogueImage.GetComponent<Image>().sprite = npcImage[1];
        } 
        else {
            questButton.SetActive(true);
            shopButton.SetActive(false);
            dialogueImage.GetComponent<Image>().sprite = npcImage[2];
        }
    }
    public void showShopOfNPC() {
        shopUI.showShopUI(nameOfNPC.text);
    }
    public IEnumerator Typing(string message) //types out each individual letter
    {
        dialogueToSay = message;
        for (int i = 0; i < dialogueToSay.Length; i++) 
        {
           dialogueTextUI.text += dialogueToSay[i];
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void zeroText() //empties the dialogue box
    {
        dialogueTextUI.text = "";
        dialogueToSay = "";
        gameObject.SetActive(false);
    }
}
