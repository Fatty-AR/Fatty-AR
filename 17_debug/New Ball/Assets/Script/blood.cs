using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class blood : MonoBehaviour
{
    //public Camera mainCamera;
    //public Camera camera1;
    public Scrollbar m_bar;
    public GameObject player;
    public Text score_text;
    private int i = 0;
    public UnityEngine.Canvas m_canvas;//»­²¼  
    public Vuforia.DefaultTrackableEventHandler targetScript;
    private ColorBlock cb;

    // Use this for initialization
    void Start()
    {
		m_bar.size = 1;
        cb = m_bar.colors;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (targetScript.start)
        {
            i++;
            if (i % 50 == 0)
            {
                m_bar.size -= 0.01f;
            }
            if (m_bar.size <= 0.3)
            {
                cb.normalColor = Color.red;
                m_bar.colors = cb;
            }
            if (m_bar.size == 0)
            {
                int score = score_text.GetComponent<score>().GetFinalScroe();
                PlayerPrefs.SetInt("player score", score);
                SceneManager.LoadScene("endgame");
            }
        }
        
    }

    public float getBlood()
    {
        return m_bar.size;
    }

    public void addBlood(float value)
    {
        m_bar.size += value;
    }

    public void minusBlood(float value)
    {
        m_bar.size -= value;
    }

}
