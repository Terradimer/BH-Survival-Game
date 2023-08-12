using System.Collections.Generic;
using UnityEngine;
using System;
using Damage;
using Effects;
using GameTime;

/* The Actor class represents a game entity with position, health, speed, activeEffects, and hooks for
executing actions on certain events. */
public class Actor : Entity {
    public float currentHP {get; protected set;}
    public float maxHP {get; protected set;}
    private List<Effect> activeEffects = new List<Effect>();

    protected virtual void Awake() {
        maxHP = 100;
        currentHP = maxHP;
        GameClock.OnTickUpdate += OnTick;

        # region Effect Testing
        // Using standard lifetime conversion
        // Effect testing = LifeTime.AsLifeTime<Effect>(EffectCompendium.GetEffect(EffectTag.Burning), 10);
        // testing.Time.Begin();
        // AddEffect(testing);

        // Using effect-class specific lifetime instantiation  
        AddEffect(EffectCompendium.GetEffect(EffectTag.Burning).WithLifeTime(30));
        //AddEffect(EffectCompendium.GetEffect(EffectTag.Burning).WithLifeTime(15));

        //AddEffect(EffectCompendium.GetEffect(EffectTag.Burning).SetDuration(60));
        //AddEffect(EffectCompendium.GetEffect(EffectTag.Fire_Resistance).ToggleDuration(false));

        // No Lifetime
        AddEffect(EffectCompendium.GetEffect(EffectTag.Fire_Resistance));
        # endregion
    }

    public virtual void OnTick() {
        foreach (var effect in activeEffects) 
            if(effect is IEffectOnTick ontick) ontick.Invoke();
    }

    public virtual void AddEffect(Effect effect) {
        if (effect == null) return;
        foreach (var eff in activeEffects) 
            if(eff is IEffectOnAddEffect onappeffect) onappeffect.Invoke();

        activeEffects.Add(effect);
        effect.Holder = this;
        if(effect is IEffectOnApply onapply) onapply.Invoke();
    }

    public virtual void RemoveEffect(Effect effect) {
        if (effect == null || !activeEffects.Contains(effect)) return;
        foreach (var eff in activeEffects) 
            if(eff is IEffectOnRemoveEffect onremeffect) onremeffect.Invoke();

        activeEffects.Remove(effect);
        if(effect is IEffectOnRemove onremove) onremove.Invoke();
    }

    public virtual void ApplyDamage (DamageInstance instance) {
        foreach (var effect in activeEffects) 
            if(effect is IEffectOnApplyDamage ondamage) ondamage.Invoke(ref instance);

        currentHP -= instance.amount;
    }

    protected virtual void RemoveRefs() {
        GameClock.OnTickUpdate -= OnTick;
    }

    protected virtual void AddRefs() {
        GameClock.OnTickUpdate += OnTick;
    }

    public virtual void OnDisable() {
        RemoveRefs();
    }

    public virtual void OnDestroy() {
        RemoveRefs();
    }

    public virtual void OnEnable() {
        AddRefs();
    }
}