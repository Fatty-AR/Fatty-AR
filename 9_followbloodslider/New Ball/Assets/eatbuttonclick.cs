using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatbuttonclick : MonoBehaviour {
	public GameObject circle;
    private Button thisButton;
    private string eatableName = "", lastAteFood = "null";

    void Start () {
        thisButton = this.GetComponent<Button> ();
        thisButton.onClick.AddListener (OnClick);
        thisButton.interactable = false;
    }

    private void OnClick(){
        if (eatableName != "" && lastAteFood != eatableName)
        {
            circle.SetActive(true);
        }
    }
    

    private void Update()
    {
        //盘中食物的根节点
        //playerPos = player.transform.position;
        /*NearestFood = GetNearestFood(playerPos);
        Vector3 realSize = NearestFood.GetComponent<MeshFilter>().mesh.bounds.size;
        float realX = realSize.x * transform.lossyScale.x;
        float realY = realSize.y * transform.lossyScale.y;
        float realZ = realSize.z * transform.lossyScale.z;
        float realDis = Mathf.Sqrt(realX*realX + realY*realY + realZ*realZ);
        float leastDis = Vector3.Distance(playerPos, NearestFood.transform.position);
        if (leastDis <= (realDis+0.8) && lastAteFood != NearestFood &&NearestFood.activeInHierarchy)
        {
            thisButton.interactable = true;
        } else
        {
            thisButton.interactable = false;
        }*/
        
    }

    /*private GameObject GetNearestFood(Vector3 playerPosition)
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
        leastIndex = least;
        return FoodRoot.transform.GetChild(least).gameObject;
    }*/

    public void EatableName(string name)
    {
        eatableName = name;
        if (name == lastAteFood)
        {
            thisButton.interactable = false;
        }
    }
}