using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class introbuttonclick : MonoBehaviour {

    public Canvas introduccanvas;

    private Button thisButton;

    // Use this for initialization
    void Awake() {
        introduccanvas.gameObject.SetActive(false);
        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(OnClick);
        Debug.Log("start");
    }
	


	// Update is called once per frame
	void OnClick() {
        introduccanvas.gameObject.SetActive(true);
        Debug.Log("OnClick");
    }
}
