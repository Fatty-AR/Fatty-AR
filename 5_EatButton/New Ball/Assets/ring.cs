using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private ColorBlock cb;

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
            }
            currentAmout = 0;
            controller.enabled = true;
            switchButton.interactable = true;
            circle.SetActive(false);
		}
		
	}

	
	public void SetTargetProcess(int target)
	{
		if(target >= 0 && target <= 100)
			targetProcess = target;
	}
}
