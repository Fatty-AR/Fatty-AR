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

	public GameObject circle;
	
	// Use this for initialization
	void Start () {
		currentAmout = 0;
		targetProcess = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentAmout < targetProcess) {
			Debug.Log("currentAmount:" + currentAmout.ToString());
			
			currentAmout += speed;
			if(currentAmout > targetProcess)
				currentAmout = targetProcess;
			indicator.GetComponent<Text>().text = ((int)currentAmout).ToString() + "%";
			process.GetComponent<Image>().fillAmount = currentAmout/100.0f;
		} else {
			currentAmout = 0;
			circle.SetActive(false);
		}
		
	}

	
	public void SetTargetProcess(int target)
	{
		if(target >= 0 && target <= 100)
			targetProcess = target;
	}
}
