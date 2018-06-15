using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatbuttonclick : MonoBehaviour {
	public GameObject circle;
    private Button thisButton;
    private GameObject FoodRoot, NearestFood;
    private GameObject lastAteFood = null;//记录上一次吃过的食物 不可原地连吃两次

    void Start () {
        thisButton = this.GetComponent<Button> ();
        thisButton.onClick.AddListener (OnClick);
        thisButton.interactable = false;
        FoodRoot = GameObject.Find("ImageTarget/SilverTraySq");
    }

    private void OnClick(){
        if (lastAteFood != NearestFood && NearestFood.activeInHierarchy)
        {
            circle.SetActive(true);
            lastAteFood = NearestFood;
            Debug.Log("Eat "+lastAteFood.name);
        }
    	
    }

    private void Update()
    {
        //盘中食物的根节点
        GameObject root = GameObject.Find("ImageTarget");
        Vector3 playerPos; //用于存储两者坐标

        playerPos = root.transform.Find("MobileMaleFreeSimpleMovement1").gameObject.transform.position;
        NearestFood = GetNearestFood(playerPos);
        float leastDis = Vector3.Distance(playerPos, NearestFood.transform.position);
        if (leastDis < 0.9 && lastAteFood != NearestFood &&NearestFood.activeInHierarchy)
        {
            thisButton.interactable = true;
        } else
        {
            thisButton.interactable = false;
        }
    }

    private GameObject GetNearestFood(Vector3 playerPosition)
    {
        Vector3 foodPosition;
        float leastDistance = 10000;
        int i,least = 0;
        int foodCount = FoodRoot.transform.childCount;
        for (i = 0; i < foodCount; i++)
        {
            foodPosition = FoodRoot.transform.GetChild(i).gameObject.transform.position;
            float dis = Vector3.Distance(playerPosition, foodPosition);
            if (dis < leastDistance)
            {
                leastDistance = dis;
                least = i; 
            }
        }
        return FoodRoot.transform.GetChild(least).gameObject;
    }

}