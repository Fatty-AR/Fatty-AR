using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class blood : MonoBehaviour
{
    public Camera mainCamera;
    public Camera camera1;
    public Scrollbar m_bar;
    public GameObject player;
	private int i = 0;
    public UnityEngine.Canvas m_canvas;//画布  

    // Use this for initialization
    void Start()
    {
		m_bar.size = 1;
    }
 
    // Update is called once per frame
    void Update()
    {
        /*if (mainCamera.GetComponent<Camera>().targetTexture == null) //全局视角
        {
            //目标世界坐标转画布坐标  
            Vector3 worldToScreenPoint = mainCamera.WorldToScreenPoint(player.transform.position);
            //在画布上对应的点  
            worldToScreenPoint = new Vector3(worldToScreenPoint.x, worldToScreenPoint.y, m_canvas.planeDistance);
            Vector3 screenToWorldPoint = mainCamera.ScreenToWorldPoint(worldToScreenPoint);
            //得到最终画布坐标系中的投影点  
            Vector3 projPoint = m_canvas.transform.worldToLocalMatrix.MultiplyPoint(screenToWorldPoint);

            this.transform.localPosition = projPoint;
        } else {

        }*/
        i++;
        if (i % 50 == 0)
        {
            m_bar.size -= 0.01f;
        }
        if (m_bar.size == 0)
        {
            SceneManager.LoadScene("endgame");
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
