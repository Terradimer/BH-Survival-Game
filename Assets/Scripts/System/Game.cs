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