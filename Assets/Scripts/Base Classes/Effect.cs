using UnityEngine;
using System;

/* The Effect class represents an effect that can be applied to an Actor, with properties such as
duration, cooldown, and hookable effects. */
public class Effect {
    private bool durationPaused = true, itterToggled = false;
    private Actor holder;
    private int duration, ticksPerEffectProck = 0, ticksSinceLastEffectProc = 0;
    public bool onCoolDown {get; private set;} = false;
    public Delegate HookEffect {get; private set;} = null;
    public Actor.getHook Hook {get; private set;} = Actor.getHook.None;

    /// <summary>
    /// Sets the hook and hook effect for an actor.
    /// </summary>
    /// <param name="hook">The "hook" parameter is of type Actor.getHook, which is a delegate that
    /// represents a method that takes no parameters and returns an object. It is used to get the hook
    /// object.</param>
    /// <param name="Delegate">A delegate is a type that represents references to methods with a
    /// particular parameter list and return type. It can be used to pass methods as arguments to other
    /// methods or to store methods in data structures such as arrays or lists.</param>
    /// <returns>
    /// Returns itself.
    /// </returns>
    public Effect HookTo(Actor.getHook hook, Delegate hookEffect = null) {
        HookEffect = hookEffect;
        Hook = hook;
        return this;
    }

    /// <summary>
    /// Checks if a cooldown is active, and if not, invokes it's hook effect
    /// with an object parameter.
    /// </summary>
    /// <param name="obj">The obj parameter is an object that will be passed as an argument to the
    /// HookEffect method when it is dynamically invoked.</param>
    /// <returns>
    /// void
    /// </returns>
    public void TryInvoke(object obj) {
        if(onCoolDown) return;
        if(!onCoolDown && ticksPerEffectProck > 0) onCoolDown = true;
        if(obj != null) HookEffect.DynamicInvoke(obj);
        else HookEffect.DynamicInvoke();
    }

    private void itterateTick() {
        if (!durationPaused) {
            if(duration == 0) {
                holder.RemoveEffect(this);
                if (itterToggled) Game.onTickUpdate -= itterateTick;
            }
            duration --;
        }

        if(ticksPerEffectProck < 0 || onCoolDown == false) return;
        else if (ticksSinceLastEffectProc >= ticksPerEffectProck) {
            onCoolDown = false;
            ticksSinceLastEffectProc -= ticksPerEffectProck;
        }
        else ticksSinceLastEffectProc ++;
    }

    public Effect SetTicksPerEffectProck(int tpep) {
        ticksPerEffectProck = tpep;
        return this;
    }

    /// <summary>
    /// Adds or removes the `itterateTick` method from the
    /// `Game.onTickUpdate` event based on the value of the `toggle` parameter.
    /// </summary>
    /// <param name="toggle">The toggle parameter is a boolean value that determines whether to enable
    /// or disable the itterateTick method. If toggle is true, the itterateTick method will be
    /// subscribed to the Game.onTickUpdate event. If toggle is false, the itterateTick method will be
    /// unsubscribed from the</param>
    /// <returns>
    /// Returns itself
    /// </returns>
    public Effect ToggleItter(bool toggle) {
        if(itterToggled != toggle && toggle) Game.onTickUpdate += itterateTick;
        else if (itterToggled != toggle && !toggle) Game.onTickUpdate -= itterateTick;
        itterToggled = toggle;
        return this;
    }

    /// <summary>
    /// Toggles the durationPaused variable and returns the current instance
    /// of the Effect class.
    /// </summary>
    /// <param name="toggle">The "toggle" parameter is a boolean value that determines whether the
    /// duration of the effect should be paused or resumed. If "toggle" is true, the duration will be
    /// paused. If "toggle" is false, the duration will be resumed.</param>
    /// <returns>
    /// Returns itself
    /// </returns>
    public Effect ToggleDuration(bool toggle) {
        durationPaused = toggle;
        return this;
    }

    /// <summary>
    /// Sets the owner of an Effect object and returns the modified object.
    /// </summary>
    /// <param name="Actor">The "Actor" parameter is the object that will be set as the owner of the
    /// effect.</param>
    /// <returns>
    /// Returns itself.
    /// </returns>
    public Effect SetOwner(Actor own) {
        holder = own;
        return this;
    }

    /// <summary>
    /// Sets the duration of an effect and returns the effect itself.
    /// </summary>
    /// <param name="dur">dur is an integer representing the duration of an effect.</param>
    /// <returns>
    /// Returns itself.
    /// </returns>
    public Effect SetDuration(int dur) {
        durationPaused = !(dur > 0);
        duration = (durationPaused) ? 0 : dur; 
        ToggleItter(true);
        return this;
    }

    public int GetDuration() { return duration; }
    public Actor GetOwner() { return holder; }
    public int GetTicksPerEffectProck() { return ticksPerEffectProck; }
}