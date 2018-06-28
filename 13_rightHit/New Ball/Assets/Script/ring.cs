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
    public GameObject doorPrefab;
    public Eat eatScript;
    public Buffs buffScript;
    private bool canexit = false;
    private Transform handle;
    private bool eating = false;
    public score scoreScript;

    // Use this for initialization
    void Start () {
		currentAmout = 0;
		targetProcess = 100;
        handle = satisfiedBar.transform.Find("Sliding Area/Handle");
    }
	
	// Update is called once per frame
	void Update () {
		
		if (currentAmout < targetProcess) {
            eating = true;
            controller.enabled = false;
            switchButton.interactable = false;
            //Debug.Log("currentAmount:" + currentAmout.ToString());
            currentAmout += speed;
			if(currentAmout > targetProcess)
				currentAmout = targetProcess;
			indicator.GetComponent<Text>().text = ((int)currentAmout).ToString() + "%";
			process.GetComponent<Image>().fillAmount = currentAmout/100.0f;
		} else {
            eating = false;
            satisfiedBar.size += 0.08f;
            healthBar.size += 0.05f;
            if (satisfiedBar.size >= 0.75f)
            {
                if (canexit == false)
                {
                    Vector3 exitposition;
                    Vector3 exitrotation;
                    System.Random randomnum = new System.Random();
                    System.Random positionnum = new System.Random();
                    int key = randomnum.Next(1, 4);
                    if (key == 1)
                    {
                        exitposition.x = -3.8f;
                        int posi = positionnum.Next(0, 5);
                        exitposition.z = posi - 3;
                        exitposition.y = 0.0f;
                        exitrotation.x = 0.0f;
                        exitrotation.y = 90.0f;
                        exitrotation.z = 0.0f;
                    } else if (key == 2)
                    {
                        exitposition.x = 4.4f;
                        int posi = positionnum.Next(0, 5);
                        exitposition.z = posi - 3;
                        exitposition.y = 0.0f;
                        exitrotation.x = 0.0f;
                        exitrotation.y = -90.0f;
                        exitrotation.z = 0.0f;
                    } else if (key == 3)
                    {
                        exitposition.z = -3.1f;
                        int posi = positionnum.Next(0, 8);
                        exitposition.x = posi - 4;
                        exitposition.y = 0.0f;
                        exitrotation.x = 0.0f;
                        exitrotation.y = 0.0f;
                        exitrotation.z = 0.0f;
                    } else
                    {
                        exitposition.z = 2.9f;
                        int posi = positionnum.Next(0, 8);
                        exitposition.x = posi - 4;
                        exitposition.y = 0.0f;
                        exitrotation.x = 0.0f;
                        exitrotation.y = 180.0f;
                        exitrotation.z = 0.0f;
                    }
                    GameObject door = Instantiate(doorPrefab, exitposition, transform.rotation);
                    door.transform.Rotate(exitrotation);
					//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //cube.transform.position = exitposition;
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
            eatScript.SizeUp();
            AddBuff();
            scoreScript.addScore(20);
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

    public bool getIfEating()
    {
        return eating;
    }
}
