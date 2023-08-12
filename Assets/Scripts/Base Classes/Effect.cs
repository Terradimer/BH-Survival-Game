using System.Collections.Generic;
using UnityEngine;
using GameTime;
using Damage;

namespace Effects {
    public class Effect : ILifeTime {
        public LifeTime Time {get; set;}
        public Actor Holder {get; set;}

        public void OnEnd() { 
            Holder.RemoveEffect(this);
        }
        public Effect WithLifeTime(int numTicks) {
            if(Time == null) Time = new LifeTime(this, numTicks);
            Time.Begin();
            return this;
        }
    }

    // public sealed class EffectGroup : Effect, IEffectOnApply, IEffectOnRemove {
    //     private List<Effect> _effects = new List<Effect>();

    //     public EffectGroup(params Effect[] effects) {
    //         foreach (var effect in effects)
    //             if (effect is IEffectDuration hasduration) _effects.Add(hasduration.TDuration = null);
    //             else _effects.Add(effect);
    //     }

    //     void IEffectOnApply.Invoke() => _effects.ForEach(x => Holder.AddEffect(x));

    //     void IEffectOnRemove.Invoke() => _effects.ForEach(x => Holder.RemoveEffect(x));
    // }

    public interface IEffectOnApplyDamage {
        void Invoke(ref DamageInstance instance);
    }

    public interface IEffectOnApply {
        void Invoke();
    }

    public interface IEffectOnRemove {
        void Invoke();
    }

    public interface IEffectOnTick  {
        void Invoke();
    }

    public interface IEffectOnAddEffect {
        void Invoke();
    }

    public interface IEffectOnRemoveEffect {
        void Invoke();
    }

    public interface IEffectCooldown {
        Timer Cooldown {get; set;}
    }
}