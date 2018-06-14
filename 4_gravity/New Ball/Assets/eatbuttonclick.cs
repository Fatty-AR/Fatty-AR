using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eatbuttonclick : MonoBehaviour {

	public GameObject circle;
	public Scrollbar satisfiedBar, healthBar;
	private ColorBlock cb;

    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
    	circle.SetActive(true);
    	satisfiedBar.size += 0.2f;
    	healthBar.size += 0.05f;
    	if (satisfiedBar.size >= 0.75f) {
    		cb = satisfiedBar.colors;
    		cb.normalColor = Color.red;
    		satisfiedBar.colors = cb;
    	}
        Debug.Log ("Button Clicked. ClickHandler.");
    }

}