using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Timer
{
    private int _delay => 1000;
    public bool _timerComplete { get; private set; } = false;

    public async Task RunTimer(int time, Action onCompleteTimer)
    {
        while (time > 0)
        {

            await Task.Run(() => Task.Delay(_delay));
            time -= _delay;

            Debug.Log(time);
        }

        _timerComplete = true;

        onCompleteTimer?.Invoke();
    }
}
