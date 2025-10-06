using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerManager : MonoBehaviour, MinigameSubscriber
{
    public List<Timer> Timers;

    public void OnMinigameStart()
    {
        StartTimers(0);
    }

    public void OnTimerEnd()
    {
       // throw new System.NotImplementedException();
    }

    public void StartTimers(int index)
    {
        if (Timers.Count <= 0)
        {
            return;
        }

        StartCoroutine(RunningTimer(index));
    }
        

    private IEnumerator RunningTimer(int index)
    {
        Timer timer = Timers[index];
        timer.OnTimerStartEvent.Invoke();
        yield return new WaitForSeconds(timer.duration);
        timer.OnTimerEndEvent.Invoke();

        int nextIndex = index + 1;
        if (nextIndex < Timers.Count)
        {
            StartCoroutine(RunningTimer(nextIndex));
        }
    }

}
