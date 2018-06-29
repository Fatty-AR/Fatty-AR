using System.Collections.Generic;
using UnityEngine;

public class CenterTimer : MonoBehaviour {

    static List<Timer> timers = new List<Timer>();
    private int i = 0;

    //添加计时器
    public static void AddTimer(Timer timer)
    {
        timers.Add(timer);
    }

    //移除计时器
    public static void RemoveTimer(Timer timer)
    {
        timers.Remove(timer);
    }

    //每帧更新
    void Update()
    {
        for (i = timers.Count - 1; i >= 0; i--)
        {
            timers[i].Update();
        }
    }
}
