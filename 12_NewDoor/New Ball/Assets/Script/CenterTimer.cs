using System.Collections.Generic;
using UnityEngine;

public class CenterTimer : MonoBehaviour {

    static List<Timer> timers = new List<Timer>();

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
        foreach (var timer in timers)
        {
            timer.Update();
        }
    }
}
