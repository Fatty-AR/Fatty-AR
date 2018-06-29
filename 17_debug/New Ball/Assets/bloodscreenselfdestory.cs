using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bloodscreenselfdestory : MonoBehaviour {

    public Image bloodscreen;
    public Sprite trans;
    public Sprite blood;

    // Use this for initialization
    void Start () {
        bloodscreen.sprite = trans;
    }

    public void behit ()
    {
        bloodscreen.sprite = blood;
        Timer timer;
        timer = new Timer(1.0f);
        timer.OnEnd += dest;
        timer.Start();
        //Sprite sp = Resources.Load("Textrues/yutujing", typeof(Sprite)) as Sprite;
        //bloodscreen.sprite = sp;
        Debug.Log("des");
        //bloodscreen.gameObject.SetActive(false);
    }

    void dest()
    {
        bloodscreen.sprite = trans;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
