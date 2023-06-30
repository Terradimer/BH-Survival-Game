using System.Collections.Generic;
using UnityEngine;

/* The Actor class represents a game entity with position, health, speed, effects, and hooks for
executing actions on certain events. */
public class Actor : MonoBehaviour {

    // TODO: this position method is syntactic sugar that should be pushed to the entity class when its made
    public Vector2 position { 
        get { return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); }
    }

    //* NOTE: Speed is not an Actor variable, it is an Entity variable
    // TODO: Make an enity class which parents anything interacting on the map (Actors, Projectiles, ect)
    private Dictionary<string, int> stats = new Dictionary<string, int>() {
        {"maxHP", 100}, {"currentHP", 50}
    };
    private HashSet<Effect> effects = new HashSet<Effect>();
    private Dictionary<getHook, HashSet<Effect>> hooks = new Dictionary<getHook, HashSet<Effect>>();
    public enum getHook {None, OnTick, AddEffect, RemoveEffect, ApplyDamage}

    private void Awake() {
        Game.onTickUpdate += OnTick;
    }

    /// <summary>
    /// Adds an effect to a hook if the hook is not 
    /// None and the hook does not already contain the effect.
    /// </summary>
    /// <param name="getHook">getHook is an enum type that represents different types of hooks. It is
    /// used to determine which hook to add the effect to.</param>
    /// <param name="Effect">The "Effect" parameter is an object that represents some kind of effect or
    /// action that will be associated with the hook. It could be a method, a delegate, or any other
    /// type of object that can be executed or invoked.</param>
    /// <returns>
    /// If the `hook` parameter is equal to `getHook.None`, then the method will return without
    /// performing any further actions.
    /// </returns>
    public void Hook(getHook hook, Effect e) {
        if (hook == getHook.None) return;
        if (!hooks.ContainsKey(hook))
            hooks[hook] = new HashSet<Effect>();

        hooks[hook].Add(e);
    }

    /// <summary>
    /// Removes an effect from a specified hook if it exists.
    /// </summary>
    /// <param name="getHook">getHook is an enum type that represents different types of hooks. It is
    /// used to identify a specific hook in the hooks dictionary.</param>
    /// <param name="Effect">The "Effect" parameter is an object that represents the effect that needs
    /// to be unhooked from a specific hook.</param>
    /// <returns>
    /// If the condition in the if statement is true, then nothing is being returned. If the condition
    /// is false, then the method will return void.
    /// </returns>
    public void Unhook(getHook hook, Effect e) {
        if (hook == getHook.None || !hooks.ContainsKey(hook) || hook == getHook.None) return;
        hooks[hook].Remove(e);
        if(hooks[hook].Count == 0) hooks.Remove(hook);
    }

    /// <summary>
    /// Executes a series of actions associated with a specific hook, passing an input
    /// object to each action.
    /// </summary>
    /// <param name="getHook">The parameter "getHook" is a variable of type "getHook". It is used to
    /// specify the hook for which the actions need to be executed.</param>
    /// <param name="input">The "input" parameter is an object that represents the input data that will
    /// be passed to the hook actions.</param>
    /// <returns>
    /// If the condition `!hooks.ContainsKey(hook)` is true, then nothing is being returned. If the
    /// condition is false, then the method will execute the foreach loop and no explicit return
    /// statement is provided within the loop. Therefore, nothing is being returned in this method.
    /// </returns>
    private void ExecuteHookActions(getHook hook, object input) {
        if (!hooks.ContainsKey(hook)) return;
        foreach (var action in hooks[hook]) 
            action.TryInvoke(input);
    }

    public Actor UpdateStat(string key, int value) {
        if(!stats.ContainsKey(key)) return this;
        stats[key] = value;
        return this;
    }
    
    public void OnTick() { ExecuteHookActions(getHook.OnTick, null); }

    public void AddEffect(Effect effect) {
        ExecuteHookActions(getHook.AddEffect, effect);

        if (effect == null || !effects.Add(effect)) return;
        if (effect.Hook != getHook.None) Hook(effect.Hook, effect);
        effect.SetOwner(this);
        if (effect.OnApplyEffect != null) effect.OnApplyEffect.DynamicInvoke();
    }

    public void RemoveEffect(Effect effect) {
        ExecuteHookActions(getHook.RemoveEffect, effect);

        if (effect == null || !effects.Remove(effect)) return;
        if (effect.Hook != getHook.None) Unhook(effect.Hook, effect);
        if (effect.OnRemoveEffect != null) effect.OnRemoveEffect.DynamicInvoke();
    }

    public void ApplyDamage (DamageInstance projectile) {
        ExecuteHookActions(getHook.ApplyDamage, projectile);
        
        stats["currentHP"] -= projectile.damage;
    }

    public int? GetStat(string key) {
        if(!stats.ContainsKey(key)) return null;
        return stats[key];
    }
}
