using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour {
    private int final;

    public Text text;

    // Use this for initialization
    void Start () {
        final = PlayerPrefs.GetInt("player score");
        text.text += final.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
