using UnityEngine.UI;
using UnityEngine;

public class Eat : MonoBehaviour {

    public Button eatButton;
    private GameObject food;
    private string LastEatFood = "";
    public eatbuttonclick buttonScript;
    private int playerSize;
    private Timer timer;
    // Use this for initialization
    void Start () {
        playerSize = 1;
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
        if (food.tag == "Food" && food.name != LastEatFood)
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

    public void EatFood(string name)
    {
        LastEatFood = name;
    }

    public int GetPlayerSize()
    {
        return playerSize;
    }

    public void SizeUp() //小人吃完东西后变胖
    {
        this.transform.localScale *= 1.02f;
        playerSize += 1;
    }
}
