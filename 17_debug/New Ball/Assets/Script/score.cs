using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    private int myScore;
    public Text score_text;
    // Use this for initialization
    void Start () {
        myScore = 0;
        //DontDestroyOnLoad(score_text.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
        score_text.text = myScore.ToString();
    }

    public void addScore(int value)
    {
        myScore += value;
    }

    public void minusScore(int value)
    {
        myScore -= value;
    }

    public int GetFinalScroe()
    {
        return myScore;
    }
}
