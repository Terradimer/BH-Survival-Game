using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void Affect (EntityData e = null);

public class EntityData {
    public static EntityData empty { get { return new EntityData(); } }
    protected bool durationPaused = false;
    protected Actor holder, origin;
    protected int duration, ticksPerEffectProck = 0, ticksSinceLastEffectProc = 0;

    public EntityData(Actor holder = null, Actor origin = null, int duration = -1, int ticksPerEffectProck = -1) {
        this.holder = holder;
        this.origin = origin;
        this.duration = duration;
        this.ticksPerEffectProck = ticksPerEffectProck;
    }
}
