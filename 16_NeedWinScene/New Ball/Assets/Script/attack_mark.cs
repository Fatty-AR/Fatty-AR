using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack_mark : MonoBehaviour
{
    private int transparent = 1;
    public Image attackMark;
    private Color color;
    private int i = 0;
    private bool EableMarkFlash = false;
    private bool NoticeBuff = false;

    // Use this for initialization
    void Start()
    {
        color = attackMark.color;
        color.a = 0;
        attackMark.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (EableMarkFlash && NoticeBuff)
        {
            i = (i + 1) % 1000;
            if (i % 3 == 0)
            {
                transparent ^= 1;
                if (transparent == 0)
                {
                    color.a = 0;
                }
                else
                {
                    color.a = 1;
                }
                attackMark.color = color;
            }
        }
    }

    public void MarkFlash() //开始 叉子警告闪烁
    {
        EableMarkFlash = true;
    }

    public void DisableMarkFlash()// 关闭 叉子警告闪烁
    {
        EableMarkFlash = false;
        color.a = 0;
        attackMark.color = color;
    }

    public bool GetNoticeBuff() //return true 表示已获得“叉子警告”
    {
        return NoticeBuff;
    }

    public void SetNoticeBuff(bool buff)
    {
        NoticeBuff = buff;
    }
}
