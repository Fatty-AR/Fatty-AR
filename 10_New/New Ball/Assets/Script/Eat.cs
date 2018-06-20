using UnityEngine.UI;
using UnityEngine;

public class Eat : MonoBehaviour {

    public Button eatButton;
    private GameObject LastEatFood, food;
    public eatbuttonclick buttonScript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        food = collision.gameObject;
        if (food.tag == "Food")
        {
            buttonScript.EatableName(food.name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        food = collision.gameObject;
        if (food.tag == "Food")
        {
            eatButton.interactable = true;

        } else
        {
            eatButton.interactable = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        food = collision.gameObject;
        if (food.tag == "Food")
        {
            buttonScript.EatableName("");
        }
    }
}
