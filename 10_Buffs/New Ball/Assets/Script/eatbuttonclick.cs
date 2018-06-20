using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatbuttonclick : MonoBehaviour {
	public GameObject circle;
    private Button thisButton;
    private string eatableName = "", lastAteFood = "null";
    public Eat eatScript;

    void Start () {
        thisButton = this.GetComponent<Button> ();
        thisButton.onClick.AddListener (OnClick);
        thisButton.interactable = false;
    }

    private void OnClick(){
        if (eatableName != "" && lastAteFood != eatableName)
        {
            circle.SetActive(true);
            eatScript.EatFood(eatableName);
        }
    }
    

    private void Update()
    {
        
    }


    public void EatableName(string name)
    {
        eatableName = name;
        if (name == lastAteFood)
        {
            thisButton.interactable = false;
        }
    }
}