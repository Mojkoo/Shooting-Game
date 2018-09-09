﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework.Internal.Execution;
using UnityEngine;
using System.Threading;
using System;

public class Timer : MonoBehaviour
{
    public float time;
    private float originalTime;

    private bool tick = false;
    private OnFinish onFinish;

    public delegate void OnFinish();

    public void Initilize(OnFinish onFinish)
    {
        if (this.time > 0)
        {
            this.originalTime = this.time; 
        }
        else
        {
            this.time = this.originalTime;
        }

        this.tick = true;
        this.onFinish = onFinish;
    }

    public float GetOriginalTime()
    {
        return originalTime;
    }

    private void Update()
    {
        if (tick)
        {
            this.time -= 1 * Time.deltaTime;

            if (this.IsFinished())
            {
                this.time = originalTime;
                this.tick = false;
                this.onFinish.Invoke();
            }
        }
    }

    public bool IsFinished()
    {
        return (this.time <= 0 || this.originalTime <= 0 || tick == false);
    }
}








































//private int time;
    
   































    
/*
private int time;
private int startTime;
private Thread thread;

public delegate void EndDelegate();

private EndDelegate endMethod;

public Timer(EndDelegate endMethod, int milliseconds)
{
    this.time = milliseconds;
    this.startTime = milliseconds;
    this.endMethod = endMethod;

    ThreadPool.QueueUserWorkItem(Update, this);
}

private void Update(object state)
{
    while (true)
    {
        Timer @this = (Timer)state;
    
        Debug.Log("Update: " + time);
        @this.time--;
         if (time <= 0)
         {
             @this.endMethod.Invoke();
             break;
         }
    }
}
*/


/*private float time;
private TimeType timeType;

public Timer(float time, TimeType timeType)
{
    this.time = time;
    this.timeType = timeType;
    ThreadPool.QueueUserWorkItem(Update, this);
}

private void Update(object o)
{
    Timer @this = (Timer) o;
    while (@this.time > 0)
    {
        switch(@this.timeType)
        {
            case TimeType.Seconds:
                TimeHelper.TickSeconds(@this.time);
                break;
        }  
    }
}*/