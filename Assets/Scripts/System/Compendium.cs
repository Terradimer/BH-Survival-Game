using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class Compendium {
    public enum DamageType {None, Energy, Balistic, Fire, Ect}
    private static Dictionary<string, Effect> _effects_ = new Dictionary<string, Effect>() {
        {"Burning", new Effect()
            .HookTo(
                Actor.getHook.OnTick,
                new Action<Actor>((Actor actor) => {
                    actor.ApplyDamage(new Projectile(4, DamageType.Fire));
                    Debug.Log(actor.currentHP);
                }))
            .SetTicksPerEffectProck(5)
            .SetDuration(30)
        },
        {"Fire_Resistance", new Effect()
            .HookTo(
                Actor.getHook.ApplyDamage,
                new Action<Projectile>((Projectile p) => {
                    if (p.damageType == DamageType.Fire) p.damage /= 2;
                })
            )
        }
    };

    public static Effect GetEffect(string key) {
        if(!_effects_.ContainsKey(key)) return null;
        return _effects_[key];
    }
}
