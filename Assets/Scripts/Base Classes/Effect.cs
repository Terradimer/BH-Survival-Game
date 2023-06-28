using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Effect : EntityData {
    public List<(Actor.getHook, Delegate)> hookEffects {get; private set;} = new List<(Actor.getHook, Delegate)>();

    public Effect HookTo(Actor.getHook hook, Delegate apply = null) {
        hookEffects.Add((hook, apply));
        return this;
    }

    private void itterateTick() {
        if (duration != -1 && !durationPaused) {
            if(duration <= 0) holder.RemoveEffect(this);
            duration --;
        }

        if (ticksPerEffectProck < 0) itterEffect.Invoke(holder);
        
        else if (ticksSinceLastEffectProc >= ticksPerEffectProck) {
            itterEffect.Invoke(holder);
            ticksSinceLastEffectProc = 0;
        }
        else ticksSinceLastEffectProc ++;
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

    public Effect SetTicksPerEffectProck(int tpep) {
        ticksPerEffectProck = tpep;
        return this;
    }

    public int GetDuration() { return duration; }

    public int GetTicksPerEffectProck() { return ticksPerEffectProck; }

    public Actor GetOwner() { return holder; }
}
