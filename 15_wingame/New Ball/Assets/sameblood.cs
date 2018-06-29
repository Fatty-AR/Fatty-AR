using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class sameblood : MonoBehaviour {

    public Scrollbar m_bar;
    public Scrollbar thisbar;

    // Use this for initialization
    void Start () {
        //m_bar.size = 1;
    }
	
	// Update is called once per frame
	void Update () {
        thisbar.size = m_bar.size;
	}
}
