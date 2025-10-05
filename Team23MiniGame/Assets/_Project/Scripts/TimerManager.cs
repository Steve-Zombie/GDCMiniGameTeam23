using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public List<Timer> Timers;
    private Coroutine currentCoroutineForTimer;
    public void StartTimer(int index)
    {
        if (index < 0 || index >= Timers.Count)
        {
            return;
        }

       if (currentCoroutineForTimer != null)
            StopCoroutine(currentCoroutineForTimer);

        currentCoroutineForTimer = StartCoroutine(RunningTimer(Timers[index]));
    }
        

    private IEnumerator RunningTimer(Timer timer)
    {
        timer.OnGameStartEvent.Invoke();
        yield return new WaitForSeconds(timer.duration);
        timer.OnGameEndEvent.Invoke();
    }

}
