using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bloodscreenselfdestory : MonoBehaviour {

    public Image bloodscreen;
    public Sprite trans;
    public Sprite blood;
    private Color cb;

    // Use this for initialization
    void Start () {
        cb = bloodscreen.color;
        cb.a = 0;
        bloodscreen.color = cb;
    }

    public void behit ()
    {
        cb.a = 100;
        bloodscreen.color = cb;
        Timer timer;
        timer = new Timer(1.0f);
        timer.OnEnd += dest;
        timer.Start();
    }

    void dest()
    {
        cb = bloodscreen.color;
        cb.a = 0;
        bloodscreen.color = cb;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
