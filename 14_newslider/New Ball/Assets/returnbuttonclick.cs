using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class returnbuttonclick : MonoBehaviour
{

    public Canvas introduccanvas;

    private Button thisButton;

    // Use this for initialization
    void Awake()
    {
        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(OnClick);
        Debug.Log("start");
    }



    // Update is called once per frame
    void OnClick()
    {
        introduccanvas.gameObject.SetActive(false);
        Debug.Log("OnClick");
    }
}
