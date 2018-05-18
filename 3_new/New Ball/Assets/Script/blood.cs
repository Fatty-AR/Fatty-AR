using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class blood : MonoBehaviour
{
	public Scrollbar m_bar;
	private int i = 0;
    // Use this for initialization
    void Start()
    {
		m_bar.size = 100;
    }
 
    // Update is called once per frame
    void Update()
    {
		i++;
		if (i % 20 == 0) {
			m_bar.size -= 0.01f;
		}
    }
}
