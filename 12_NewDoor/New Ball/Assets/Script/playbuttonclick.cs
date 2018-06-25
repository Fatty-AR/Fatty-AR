using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playbuttonclick : MonoBehaviour
{
    private Button thisButton;

    void Awake()
    {
        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(OnClick);
        Debug.Log("start");
    }

    void OnClick()
    {
        Debug.Log("click");
        SceneManager.LoadScene("newBall");
    }
    
}