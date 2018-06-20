using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public ScrollCircle scroll;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(scroll.distance.x, 0, scroll.distance.y) * Time.deltaTime);
	}
}
