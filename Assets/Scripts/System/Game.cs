using UnityEngine;
using System;

public class Game : MonoBehaviour {
    public static event Action onTickUpdate;
    // TODO: Adjust TICK_TIMER_MAX to make game speed feel better (the smaller the number the more ticks/second)
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

// * Global reference Structs and Data-Classes

/* The `DamageInstance` struct represents an instance of damage. It
has two properties: `damage` and `damageType`. */
//* Must be a class, allocating to heap breaks dynamic hook calls
public class DamageInstance {
    public int damage {get; set;}
    public Compendium.DamageType damageType {get; private set;}

    public DamageInstance (int dmg, Compendium.DamageType dtype = Compendium.DamageType.None) {
        damage = dmg;
        damageType = dtype;
    }
}