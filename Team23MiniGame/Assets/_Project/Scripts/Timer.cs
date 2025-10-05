using System;
using UnityEngine.Events;

[Serializable]
public class Timer
{
    public float duration;
    public UnityEvent OnGameStartEvent;
    public UnityEvent OnGameEndEvent;

    public Timer(float duration)
    {
        this.duration = duration;
        OnGameStartEvent = new UnityEvent();
        OnGameEndEvent = new UnityEvent();
    }
}