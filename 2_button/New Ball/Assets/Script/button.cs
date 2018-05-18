using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject camera1;
    public RenderTexture minimap;

    public void Click()
    {
        if (mainCamera.GetComponent<Camera>().targetTexture == null)
        {
            mainCamera.GetComponent<Camera>().targetTexture = minimap;
            camera1.GetComponent<Camera>().targetTexture = null;
        } else
        {
            mainCamera.GetComponent<Camera>().targetTexture = null;
            camera1.GetComponent<Camera>().targetTexture = minimap;
        }

        Debug.Log("Button Clicked. TestClick.");
    }
}
