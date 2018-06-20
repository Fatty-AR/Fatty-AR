using System;
using UnityEngine;

public class Timer {

    //开始时间
    public float StartTime { get; private set; }
    //持续时间
    public float Duration { get; private set; }
    //结束时间
    public float EndTime { get; private set; }
    //当前时间
    public float CurTime { get; private set; }

    //运行标识
    public bool IsStart { get; private set; }

    //计时百分比
    public float Ratio
    {
        get
        {
            if (!IsStart)
            {
                return 0;
            }
            else
            {
                return 1 - (EndTime - CurTime) / Duration;
            }
        }
    }

    //开始和结束事件，这里直接用System.Action（相当于空返回值无参数委托）
    public Action OnStart { get; set; }
    public Action OnEnd { get; set; }
    public Action OnUpdate { get; set; }

    //构造函数，设置计时器
    public Timer(float duration)
    {
        Duration = duration;
    }

    //开始计时 Timer类不继承于MonoBehaviour，该方法不会在任何对象开始时被调用。
    public void Start()
    {
        IsStart = true;
        StartTime = Time.time;
        CurTime = StartTime;
        EndTime = StartTime + Duration;
        CenterTimer.AddTimer(this);
        if (OnStart != null) OnStart();
    }

    //更新时间，并检查状态。Timer类不继承于MonoBehaviour，该方法将在中心计时器每帧调用。
    public void Update()
    {
        if (!IsStart) return;
        CurTime += Time.deltaTime;
        if (CurTime > EndTime)
        {
            End();
        }
        else if (OnUpdate != null) OnUpdate();
    }

    //计时器结束
    void End()
    {
        IsStart = false;
        if (OnEnd != null) OnEnd();
        CenterTimer.RemoveTimer(this);
    }
}
