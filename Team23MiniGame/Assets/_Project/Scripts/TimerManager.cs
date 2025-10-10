using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerManager : MonoBehaviour

{
    public List<Timer> Timers;


    void Start()
    {
        StartTimers(0);
    }

    public void StartTimers(int index)
    {
        if (index < 0 || index >= Timers.Count)
            return;

        StartCoroutine(RunningTimer(index));
    }

    private IEnumerator RunningTimer(int index)
    {
        Timer timer = Timers[index];
        Debug.Log("Starting timer: " + timer.name + " for " + timer.duration + " seconds.");
        timer.OnTimerStartEvent.Invoke();
        yield return new WaitForSeconds(timer.duration);
        Debug.Log("Ending timer: " + timer.name);
        timer.OnTimerEndEvent.Invoke();

        int nextIndex = index + 1;

        if (nextIndex < Timers.Count)
        {
            StartCoroutine(RunningTimer(nextIndex));
        }
    }

}
