using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Timer
{
    public String name;
    public float duration;
    public UnityEvent OnTimerStartEvent;
    public UnityEvent OnTimerEndEvent;
}