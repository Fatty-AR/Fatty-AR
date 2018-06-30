using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour {
    private int final;
    private int score;
    public Text text;
    public Text text1;

    // Use this for initialization
    void Start () {
        final = PlayerPrefs.GetInt("player score");
        text.text += final.ToString();
        score = PlayerPrefs.GetInt("highestScore");
        text1.text += score.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
