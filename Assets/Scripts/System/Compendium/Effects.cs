using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Compendium.Damage;

namespace Compendium.Effects {
    
    public enum EffectTags {
        Burning, Fire_Resistance
    }

    public static class Effects {
        public static Dictionary<EffectTags, Effect> Get = new Dictionary<EffectTags, Effect>() {
            {EffectTags.Burning, new Effect()
                .HookTo(
                    Actor.getHook.OnTick,
                    new Action<Actor>((Actor actor) => {
                        actor.ApplyDamage(new DamageInstance(4, DamageType.Fire));
                        Debug.Log(actor.currentHP);
                    }))
                .SetTicksPerEffectProck(5)
                .SetDuration(30)
            },
            {EffectTags.Fire_Resistance, new Effect()
                .HookTo(
                    Actor.getHook.ApplyDamage,
                    new Action<DamageInstance>((DamageInstance p) => {
                        if (p.damageType == DamageType.Fire) p.damage /= 2;
                    })
                )
            }
        };
    }
}