using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class followblood : MonoBehaviour {

    public GameObject player;
    public GameObject bloodslider;
    public GameObject satisslider;

    public float Xoffset;
    public float Yoffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        bloodslider.transform.position = player2DPosition + new Vector2(Xoffset, Yoffset);
        satisslider.transform.position = player2DPosition + new Vector2(Xoffset, Yoffset + 4);

        //血条超出屏幕就不显示  
        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        {
            bloodslider.gameObject.SetActive(false);
        }
        else
        {
            bloodslider.gameObject.SetActive(true);
        }
    }
}
