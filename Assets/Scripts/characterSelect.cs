using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Button leftButton;
    public Button rightButton;
    public Button submitButton;

    public GameObject[] characters;
    private int index;

	void Start () {
		Button btn1 = leftButton.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClickLeft);

        Button btn2= rightButton.GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClickRight);

        Button myButton = submitButton.GetComponent<Button>();
        myButton.onClick.AddListener(TaskOnClickSubmit);

        index = 0;

        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
	}

	void TaskOnClickRight(){
        characters[index].SetActive(false);
            if (index == characters.Length - 1)
            {
                index = 0;
                characters[index].SetActive(true);
            } else {
                index++;
                characters[index].SetActive(true);
            }
	}
    void TaskOnClickLeft(){
        characters[index].SetActive(false);
            if (index == 0)
            {
                index = characters.Length - 1;
                characters[index].SetActive(true);
            } else {
                index--;
                characters[index].SetActive(true);
            }
	}

    void TaskOnClickSubmit() {
        SceneManager.LoadScene("Game");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
