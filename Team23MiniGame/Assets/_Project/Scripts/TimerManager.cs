using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerManager : MonoBehaviour

{
    public List<Timer> Timers;


    public void StartTimers(int index)
    {
        if (index < 0 || index >= Timers.Count)
            return;


        StartCoroutine(RunningTimer(index));

        }



    private IEnumerator RunningTimer(int index)
    {
        Timer timer = Timers[index];
        timer.OnTimerStartEvent.Invoke();
        yield return new WaitForSeconds(timer.duration);
        timer.OnTimerEndEvent.Invoke();
        Debug.Log($"Timer '{timer.name}' ended");

        int nextIndex = index + 1;

        if (nextIndex < Timers.Count)
        {
            StartCoroutine(RunningTimer(nextIndex));
        }

    }

}
