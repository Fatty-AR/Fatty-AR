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
    public UnityEngine.Canvas m_canvas;//����  

    // Use this for initialization
    void Start()
    {
		m_bar.size = 1;
    }
 
    // Update is called once per frame
    void Update()
    {
        /*if (mainCamera.GetComponent<Camera>().targetTexture == null) //ȫ���ӽ�
        {
            //Ŀ����������ת��������  
            Vector3 worldToScreenPoint = mainCamera.WorldToScreenPoint(player.transform.position);
            //�ڻ����϶�Ӧ�ĵ�  
            worldToScreenPoint = new Vector3(worldToScreenPoint.x, worldToScreenPoint.y, m_canvas.planeDistance);
            Vector3 screenToWorldPoint = mainCamera.ScreenToWorldPoint(worldToScreenPoint);
            //�õ����ջ�������ϵ�е�ͶӰ��  
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
