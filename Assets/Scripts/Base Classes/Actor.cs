using System.Collections.Generic;
using UnityEngine;
using System;
/* The Actor class represents a game entity with position, health, speed, effects, and hooks for
executing actions on certain events. */
public class Actor : MonoBehaviour {
    private Dictionary<string, int> stats = new Dictionary<string, int>() {
        {"maxHP", 100}, {"currentHP", 50}
    };
    private HashSet<Effect> effects = new HashSet<Effect>();
    private Dictionary<getHook, Delegate> hooks = new Dictionary<getHook, Delegate>();
    public enum getHook : byte {None, OnTick, AddEffect, RemoveEffect, ApplyDamage}

    private void Awake() {
        Game.onTickUpdate += OnTick;

        // AddEffect(Compendium.GetEffect(this, Compendium.EffectTags.Burning));
        // AddEffect(
        //     Compendium.GetEffect(this, Compendium.EffectTags.Fire_Resistance)
        //     .SetTicksPerEffectProck(6)
        // );
    }

    /// <summary>
    /// Adds a delegate to a dictionary of hooks based on a specified key.
    /// </summary>
    /// <param name="getHook">getHook is an enum that represents different types of hooks. It is used to
    /// determine which hook to add the delegate to.</param>
    /// <param name="Delegate">The "Delegate" parameter is a type that represents a delegate, which is a
    /// reference to a method. It can be used to pass a method as a parameter to another method. In this
    /// case, it is used to pass a method that will be hooked into a specific event.</param>
    /// <returns>
    /// void
    /// </returns>
    public void Hook(getHook hook, Delegate e) {
        if (hook == getHook.None) return;
        if (!hooks.ContainsKey(hook)) hooks[hook] = e;
        else hooks[hook] = Delegate.Combine(hooks[hook], e);
    }

    /// <summary>
    /// Removes a delegate from a dictionary of hooks based on a specified hook
    /// type.
    /// </summary>
    /// <param name="getHook">An enum that represents different types of hooks. It is used to determine
    /// which hook to unhook from.</param>
    /// <param name="Delegate">The "Delegate" parameter is the delegate object that you want to remove
    /// from the specified hook.</param>
    /// <returns>
    /// void
    /// </returns>
    public void Unhook(getHook hook, Delegate e) {
        if (hook == getHook.None || !hooks.ContainsKey(hook)) return;
        hooks[hook] = Delegate.Remove(hooks[hook], e);
        if(hooks[hook] == null) hooks.Remove(hook);
    }

    /// <summary>
    /// Executes the actions associated with a given hook if it exists in the dictionary.
    /// </summary>
    /// <param name="getHook">getHook is a delegate type that represents a method that takes no
    /// parameters and returns a value.</param>
    /// <param name="input">The "input" parameter is an object that represents the input data for the
    /// hook action. It can be of any type, as it is a generic object.</param>
    /// <returns>
    /// void
    /// </returns>
    private void ExecuteHookActions(getHook hook, object input) {
        if (!hooks.ContainsKey(hook)) return;
        hooks[hook].DynamicInvoke(input);
    }

    /// <summary>
    /// Updates the value of a specific key in the stats dictionary and returns the updated
    /// Actor object.
    /// </summary>
    /// <param name="key">The key parameter is a string that represents the name or identifier of the
    /// stat that you want to update.</param>
    /// <param name="value">The value parameter is an integer that represents the new value for the
    /// specified key in the stats dictionary.</param>
    /// <returns>
    /// Returns an instance of the current object (this).
    /// </returns>
    public Actor UpdateStat(string key, int value) {
        if(!stats.ContainsKey(key)) return this;
        stats[key] = value;
        return this;
    }

    /// <summary>
    /// The function "GetStat" returns the value associated with a given key in a dictionary, or null if
    /// the key is not found.
    /// </summary>
    /// <param name="key">The key parameter is a string that represents the key of the desired stat in
    /// the stats dictionary.</param>
    /// <returns>
    /// The method is returning an integer value. However, the return type is nullable, meaning it can
    /// also return null if the key is not found in the stats dictionary.
    /// </returns>
    public int? GetStat(string key) {
        if(!stats.ContainsKey(key)) return null;
        return stats[key];
    }
    
    // * Hookables

    public void OnTick() { ExecuteHookActions(getHook.OnTick, null); }

    public void AddEffect(Effect effect) {
        ExecuteHookActions(getHook.AddEffect, effect);

        if (effect == null || !effects.Add(effect)) return;
        if (effect.Hook != getHook.None) Hook(effect.Hook, (Action<object>) effect.Parse);
        effect.SetOwner(this);
        if (effect.OnApplyEffect != null) effect.OnApplyEffect.DynamicInvoke();
    }

    public void RemoveEffect(Effect effect) {
        ExecuteHookActions(getHook.RemoveEffect, effect);

        if (effect == null || !effects.Remove(effect)) return;
        if (effect.Hook != getHook.None) Unhook(effect.Hook, (Action<object>) effect.Parse);
        if (effect.OnRemoveEffect != null) effect.OnRemoveEffect.DynamicInvoke();
    }

    public void ApplyDamage (DamageInstance projectile) {
        ExecuteHookActions(getHook.ApplyDamage, projectile);
        
        stats["currentHP"] -= projectile.damage;
        Debug.Log(GetStat("currentHP"));
    }
}