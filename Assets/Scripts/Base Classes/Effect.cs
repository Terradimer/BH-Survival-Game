using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Effect : EntityData {
    public bool onCoolDown {get; private set;} = false;
    public Delegate HookEffect {get; private set;} = null;
    public Actor.getHook Hook {get; private set;} = Actor.getHook.None;

    public Effect HookTo(Actor.getHook hook, Delegate hookEffect = null) {
        HookEffect = hookEffect;
        Hook = hook;
        return this;
    }

    public void TryInvoke(object obj) {
        if(onCoolDown) return;
        onCoolDown = true;
        HookEffect.DynamicInvoke(obj);
    }

    public int GetTicksPerEffectProck() { return ticksPerEffectProck; }

    private void itterateTick() {
        if (duration != -1 && !durationPaused) {
            if(duration <= 0) holder.RemoveEffect(this);
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

    public Effect ToggleItter(bool toggle) {
        if(toggle) Game.onTickUpdate += itterateTick;
        else Game.onTickUpdate -= itterateTick;
        return this;
    }

    public Effect ToggleDuration(bool toggle) {
        durationPaused = toggle;
        return this;
    }

    public Effect SetOwner(Actor own) {
        holder = own;
        return this;
    }

    public Effect SetDuration(int dur) {
        duration = dur;
        return this;
    }

    public int GetDuration() { return duration; }

    public Actor GetOwner() { return holder; }
}