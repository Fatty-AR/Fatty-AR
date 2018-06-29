using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class button : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject camera1;
    public RenderTexture minimap;
	public bool firstPerson;
	public GameObject scroll;

    public void Start() {
        firstPerson = false;
        scroll.SetActive(false);
    }

    public void Click()
    {
        if (mainCamera.GetComponent<Camera>().targetTexture == null)
        {
            scroll.SetActive(true);
            firstPerson = true;
            mainCamera.GetComponent<Camera>().targetTexture = minimap;
            camera1.GetComponent<Camera>().targetTexture = null;
        } else
        {
            scroll.SetActive(false);
            firstPerson = false;
            mainCamera.GetComponent<Camera>().targetTexture = null;
            camera1.GetComponent<Camera>().targetTexture = minimap;
        }

        Debug.Log("Button Clicked. TestClick.");
    }
}
