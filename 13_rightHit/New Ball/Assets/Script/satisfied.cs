using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class satisfied : MonoBehaviour {
    public Scrollbar m_bar;
    private ColorBlock cb;
    // Use this for initialization
    void Start () {
        cb = this.m_bar.colors;
    }
	
	// Update is called once per frame
	void Update () {
		if (m_bar.size >= 0.75f)
        {
            cb.normalColor = Color.red;
            this.m_bar.colors = cb;
        }
	}
}
