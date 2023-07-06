using UnityEngine;
using System;

public class Game : MonoBehaviour {
     public static event Action onTickUpdate;
    // TODO: Adjust TICK_TIMER_MAX to make game speed feel better (the smaller the number the more ticks/second)
    private const float TICK_TIMER_MAX = .2f;
    private static float tickTimer, cachedTimeScale;
    public static bool paused {get; private set;}

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
            if (onTickUpdate != null) 
                onTickUpdate();
        }
    }
}

// * Global reference Structs

/* The `DamageInstance` struct represents an instance of damage. It
has two properties: `damage` and `damageType`. */
public struct DamageInstance {
    public int damage {get; set;}
    public Compendium.DamageType damageType {get; private set;}

    public DamageInstance ( int dmg, Compendium.DamageType dtype = Compendium.DamageType.None, Actor own = null ) {
        damage = dmg;
        damageType = dtype;
    }
}