using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatbuttonclick : MonoBehaviour {

	public GameObject circle;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
    	circle.SetActive(true);
        Debug.Log ("Button Clicked. ClickHandler.");
    }

}