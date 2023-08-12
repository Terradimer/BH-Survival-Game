using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Damage;
using GameTime;

namespace Effects {
    
    #region Archeypes

    public class DamageOverTime : Effect, IEffectOnTick, IEffectCooldown {
        DamageInstance AppliedDamage;
        public Timer Cooldown {get; set;}

        public DamageOverTime(DamageInstance instance, int ticksPerEffectProck = 0) {
            AppliedDamage = instance;
            Cooldown = new Timer(ticksPerEffectProck);
            Cooldown.End();
        }

        public void Invoke() {
            if (Cooldown.Elapsed) {
                Cooldown.Begin();
                Holder.ApplyDamage(AppliedDamage);
                Debug.Log(Holder.currentHP);
            }
        }
    }

    public class DamageModifier : Effect, IEffectOnApplyDamage {
        DamageType type;
        float multiplier;

        public DamageModifier(float modifiermultiplier, params DamageType[] dtypes) {
            foreach (var dtype in dtypes) type |= dtype;
            this.multiplier = modifiermultiplier;
        }

        public void Invoke(ref DamageInstance instance) {
            instance.amount *= (instance.ContainsAny(type)) ? multiplier : 1;
        }
    }

    #endregion

    public enum EffectTag {
        Burning, 
        Fire_Resistance,
        Iron_Flesh
    }

    public static class EffectCompendium {
        private static Dictionary<EffectTag, Func<Effect>> _effectsRef = new Dictionary<EffectTag, Func<Effect>>() {
            {EffectTag.Burning, () => new DamageOverTime (new DamageInstance(4, DamageType.Fire), 5)},
            {EffectTag.Fire_Resistance, () => new DamageModifier(0.5f, DamageType.Fire)},
            // {EffectTag.Iron_Flesh, () => new EffectGroup (
            //     new DamageModifier(0.5f, DamageType.Balistic, DamageType.Fire),
            //     new DamageModifier(2f, DamageType.Energy)
            // )}
        };

        public static Effect GetEffect(EffectTag tag) => _effectsRef[tag].Invoke();
    }
}