using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winscore : MonoBehaviour {
    private int final;

    public Text text;

    // Use this for initialization
    void Start () {
        final = PlayerPrefs.GetInt("player score") + 100;
        text.text += final.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
