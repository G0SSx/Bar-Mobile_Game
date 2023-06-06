using System;
using UnityEngine;

public sealed class Timer
{
    public float TimeLeft { get; private set; }

    public void SetFinishTime(float finishTime)
    {
        if (finishTime <= 0)
            throw new ArgumentException("Timer can't be set to 0 or less!");

        TimeLeft = finishTime;
    }

    public void SubtractFrameTime() =>
        TimeLeft -= Time.deltaTime;
}