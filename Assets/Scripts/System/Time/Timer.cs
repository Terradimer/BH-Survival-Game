using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer {
    public event Action OnTimerEnd;

    private bool looping, paused;
    private float timerDuration;
    private int tickCounter;

    void Start() {
        GameClock.OnTickUpdate += OnTick;
    }

    public Timer(float duration, bool loop = false) {
        timerDuration = duration;
        tickCounter = 0;
        looping = loop;
    }

    private void OnTick() {
        if (paused) return;
        tickCounter++;
        if (tickCounter < timerDuration) return;

        OnTimerEnd?.Invoke();

        if(!looping) GameClock.OnTickUpdate -= OnTick;

        Reset();
        
    }

    private void Reset() {
        tickCounter = 0;
    }
}
