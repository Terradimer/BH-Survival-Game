using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game : MonoBehaviour {
    public static event Action onTickUpdate;
    private const float TICK_TIMER_MAX = .2f;
    private float tickTimer;

    private void Update() {
        tickTimer += Time.deltaTime;
        if(tickTimer >= TICK_TIMER_MAX) {
            tickTimer -= TICK_TIMER_MAX;
            if (onTickUpdate != null) 
                onTickUpdate();
        }
    }
}
