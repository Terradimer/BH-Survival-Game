using System.Collections.Generic;
using UnityEngine;
using System;

public static class Compendium {
    public enum DamageType {None, Energy, Balistic, Fire, Ect}
    private static Actor actorReference; 
    
    // TODO: Replace forced manual implementation of Effects with a JSON refference script that decompiles into usable Effects
    public enum EffectTags {Burning, Fire_Resistance}
    private static Dictionary<EffectTags, Effect> _effects_ = new Dictionary<EffectTags, Effect>() {
        {EffectTags.Burning, new Effect()
            .HookTo(
                Actor.getHook.OnTick,
                new Action(() => 
                    actorReference.ApplyDamage(new DamageInstance(4, DamageType.Fire))
                ))
            .SetTicksPerEffectProck(5)
            .SetDuration(30)
        },
        {EffectTags.Fire_Resistance, new Effect() 
            .HookTo(
                Actor.getHook.ApplyDamage,
                new Action<DamageInstance>((DamageInstance p) => 
                    p.damage = (p.damageType == DamageType.Fire) ? p.damage / 2 : p.damage
                )
            )
        }
    };
    
    /// <summary>
    /// Returns the effect associated with a given key for a specific target actor.
    /// </summary>
    /// <param name="Actor">The "Actor" parameter represents the target actor on which the effect is
    /// being applied.</param>
    /// <param name="key">The "key" parameter is a string that represents the unique identifier of the
    /// effect that we want to retrieve.</param>
    /// <returns>
    /// The method is returning an Effect object.
    /// </returns>
    public static Effect GetEffect(Actor target, EffectTags key) {
        actorReference = target;
        if(!_effects_.ContainsKey(key)) return null;
        return _effects_[key];
    }
}
