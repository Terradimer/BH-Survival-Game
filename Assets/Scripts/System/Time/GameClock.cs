using UnityEngine;
using System;

public class GameClock : MonoBehaviour {
    // TODO: Adjust TICK_TIMER_MAX to make game speed feel better (the smaller the number the more ticks/second)
    private const float TICK_TIMER_MAX = .2f;
    public static event Action OnTickUpdate;
    
    private static float tickTimer, cachedTimeScale;
    public static bool paused {get; private set;}

    public static float SecondsToTicks(int ticks) {
        return ticks * TICK_TIMER_MAX;
    }

    public static void TogglePause(bool toggle) {
        if (toggle == paused) return;
        paused = toggle;

        if(paused == false) {
            Time.timeScale = cachedTimeScale;
            return;
        }

        cachedTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    private void Update() {
        tickTimer += Time.deltaTime;
        if(tickTimer >= TICK_TIMER_MAX) {
            tickTimer -= TICK_TIMER_MAX;
            if (OnTickUpdate != null) 
                OnTickUpdate();
        }
    }
}
