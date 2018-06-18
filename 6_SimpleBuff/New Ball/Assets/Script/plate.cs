using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour {

    public button button;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (button.firstPerson)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else
        {
            transform.eulerAngles = new Vector3(45 * Input.acceleration.x, 0, 45 * Input.acceleration.y);
            Debug.Log(transform.eulerAngles);
        }
	}
}
