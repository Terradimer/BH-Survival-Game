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
    private Dictionary<getHook, HashSet<Delegate>> hooks = new Dictionary<getHook, HashSet<Delegate>>();
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

    public void Hook(getHook hook, Delegate action) {
        if (hook == getHook.None) return;
        if (!hooks.ContainsKey(hook))
            hooks[hook] = new HashSet<Delegate>();

        hooks[hook].Add(action);
    }

    public void Unhook(getHook hook, Delegate action) {
        if (hook == getHook.None || !hooks.ContainsKey(hook) || hook == getHook.None) return;

        hooks[hook].Remove(action);
    }

    private void ExecuteHookActions(getHook hook, object input = null) {
        if (!hooks.ContainsKey(hook)) return;
        foreach (var action in hooks[hook]) 
            if(input == null) action.DynamicInvoke();
            else action.DynamicInvoke(input);
    }

    public void OnTick() {
        ExecuteHookActions(getHook.OnTick, this);
    }

    private bool processEffect(Effect e, Action<getHook, Delegate> p) {
        if (e == null || !effects.Remove(e)) return false;
        foreach(var eff in e.hookEffects)
            if (eff.Item1 != getHook.None) p.DynamicInvoke(eff.Item1, eff.Item2);
        return true;
    }

    public void AddEffect(Effect effect) {
        ExecuteHookActions(getHook.AddEffect, effect);

        if(!processEffect(effect, Unhook)) return;
        effect.ToggleItter(true);
        effect.SetOwner(this);
    }

    public void RemoveEffect(Effect effect) {
        ExecuteHookActions(getHook.RemoveEffect, effect);
        if(processEffect(effect, Unhook)) effect.ToggleItter(false);
    }

    public void ApplyDamage (Projectile projectile) {
        ExecuteHookActions(getHook.ApplyDamage, projectile);

        currentHP -= projectile.damage;
    }
}
