using System.Collections.Generic;
using UnityEngine;
using System;

public static class Compendium {
    public enum DamageType {None, Energy, Balistic, Fire, Ect}
    private static Dictionary<string, Effect> _effects_ = new Dictionary<string, Effect>() {
        {"Burning", new Effect()
            .HookTo(
                Actor.getHook.OnTick,
                new Action<Actor>((Actor actor) => {
                    actor.ApplyDamage(new DamageInstance(4, DamageType.Fire));
                    Debug.Log(actor.currentHP);
                }))
            .SetTicksPerEffectProck(5)
            .SetDuration(30)
        },
        {"Fire_Resistance", new Effect()
            .HookTo(
                Actor.getHook.ApplyDamage,
                new Action<DamageInstance>((DamageInstance p) => {
                    if (p.damageType == DamageType.Fire) p.damage /= 2;
                })
            )
        }
    };

    /// <summary>
    /// Returns an Effect object based on a given key, or null if the key is
    /// not found in the Effects dictionary.
    /// </summary>
    /// <param name="key">The key parameter is a string that represents the key of the effect that we
    /// want to retrieve from the dictionary.</param>
    /// <returns>
    /// Returns an Effect object.
    /// </returns>
    public static Effect GetEffect(string key) {
        if(!_effects_.ContainsKey(key)) return null;
        return _effects_[key];
    }
}
