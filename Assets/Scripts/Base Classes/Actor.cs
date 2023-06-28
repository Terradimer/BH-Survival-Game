using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/* The Actor class represents a game entity with position, health, speed, effects, and hooks for
executing actions on certain events. */
public class Actor : MonoBehaviour {
    public Vector2 position { 
        get { return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); }
    }
    public int currentHP {get; private set;}
    public int maxHP {get; private set;}
    public float speed {get; private set;}
    private HashSet<Effect> effects = new HashSet<Effect>();
    private Dictionary<getHook, HashSet<Effect>> hooks = new Dictionary<getHook, HashSet<Effect>>();
    public enum getHook {None, OnTick, AddEffect, RemoveEffect, ApplyDamage}

    private void Awake() {
        Game.onTickUpdate += OnTick;

        // * for testing, remove during build
        maxHP = currentHP = 30; 
        AddEffect(Compendium.GetEffect("Burning"));
        AddEffect(
            Compendium.GetEffect("Fire_Resistance")
            .SetDuration(11)
        );
    }

    public void Hook(getHook hook, Effect e) {
        if (hook == getHook.None) return;
        if (!hooks.ContainsKey(hook))
            hooks[hook] = new HashSet<Effect>();

        hooks[hook].Add(e);
    }

    public void Unhook(getHook hook, Effect e) {
        if (hook == getHook.None || !hooks.ContainsKey(hook) || hook == getHook.None) return;

        hooks[hook].Remove(e);
    }

    private void ExecuteHookActions(getHook hook, object input) {
        if (!hooks.ContainsKey(hook)) return;
        foreach (var action in hooks[hook]) 
            action.TryInvoke(input);
    }

    public void OnTick() {
        ExecuteHookActions(getHook.OnTick, this);
    }

    public void AddEffect(Effect effect) {
        ExecuteHookActions(getHook.AddEffect, effect);

        if (effect == null || !effects.Add(effect)) return;
        if (effect.Hook != getHook.None) Hook(effect.Hook, effect);
        effect.ToggleItter(true);
        effect.SetOwner(this);
    }

    public void RemoveEffect(Effect effect) {
        ExecuteHookActions(getHook.RemoveEffect, effect);

        if (effect == null || !effects.Remove(effect)) return;
        if (effect.Hook != getHook.None) Unhook(effect.Hook, effect);
        
        effect.ToggleItter(false);
    }

    public void ApplyDamage (Projectile projectile) {
        ExecuteHookActions(getHook.ApplyDamage, projectile);

        currentHP -= projectile.damage;
    }
}
