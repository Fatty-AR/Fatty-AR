using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ring : MonoBehaviour {

	[SerializeField]
	float speed;
	
	[SerializeField]
	Transform process;
	
	[SerializeField]
	Transform indicator;
	
	public int targetProcess{ get; set;}
	private float currentAmout = 0;
    public ScrollCircle controller;//虚拟摇杆
    public Button switchButton;//切换视角的按钮
    public Scrollbar satisfiedBar, healthBar;
    public GameObject circle;
    public GameObject door;
    private ColorBlock cb;
    public Buffs buffScript;
    private bool canexit = false;

    // Use this for initialization
    void Start () {
		currentAmout = 0;
		targetProcess = 100;

    }
	
	// Update is called once per frame
	void Update () {
		
		if (currentAmout < targetProcess) {
            controller.enabled = false;
            switchButton.interactable = false;
            //Debug.Log("currentAmount:" + currentAmout.ToString());
            currentAmout += speed;
			if(currentAmout > targetProcess)
				currentAmout = targetProcess;
			indicator.GetComponent<Text>().text = ((int)currentAmout).ToString() + "%";
			process.GetComponent<Image>().fillAmount = currentAmout/100.0f;
		} else {
            satisfiedBar.size += 0.08f;
            healthBar.size += 0.05f;
            if (satisfiedBar.size >= 0.75f)
            {
                cb = satisfiedBar.colors;
                cb.normalColor = Color.red;
                satisfiedBar.colors = cb;
                if (canexit == false)
                {
                    Vector3 exitposition;
                    System.Random randomnum = new System.Random();
                    System.Random positionnum = new System.Random();
                    int key = randomnum.Next(1, 12);
                    if (key >= 1 && key <= 3)
                    {
                        exitposition.x = -3.7f;
                        int posi = positionnum.Next(0, 6);
                        exitposition.z = posi - 3;
                        exitposition.y = 0.0f;
                    } else if (key >= 4 && key <= 6)
                    {
                        exitposition.x = 3.7f;
                        int posi = positionnum.Next(0, 6);
                        exitposition.z = posi - 3;
                        exitposition.y = 0.0f;
                    } else if (key >= 7 && key <= 9)
                    {
                        exitposition.z = -2.5f;
                        int posi = positionnum.Next(0, 10);
                        exitposition.x = posi - 5;
                        exitposition.y = 0.0f;
                    } else
                    {
                        exitposition.z = 2.5f;
                        int posi = positionnum.Next(0, 10);
                        exitposition.x = posi - 5;
                        exitposition.y = 0.0f;
                    }
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = exitposition;
                    canexit = true;

                    if (satisfiedBar.size >= 1.0f)
                    {
                        controller.enabled = false;
                    }
                }
            }
            currentAmout = 0;
            controller.enabled = true;
            switchButton.interactable = true;
            circle.SetActive(false);
            process.GetComponent<Image>().fillAmount = 0;
            AddBuff();
        }
		
	}

	
	public void SetTargetProcess(int target)
	{
		if(target >= 0 && target <= 100)
			targetProcess = target;
	}

    public void AddBuff()
    {
        buffScript.doBuff();
    }

    public void SpeedUp()
    {
        speed += 0.2f;
    }
}
