using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;

namespace GameTime {
    public struct TimerData : ITimerData {
        public int Duration {get; set;}
        public int RemainingTicks {get; set;}
        public TimeSlot Slot {get; set;}

        public bool Equals(TimerData other) =>
            Duration == other.Duration && RemainingTicks == other.RemainingTicks;
        
        
        public override int GetHashCode() =>
            17 * (23 + Duration.GetHashCode()) * (23 + RemainingTicks.GetHashCode());
    }

    public class Timer : ITimerType {
        public ITimerData Data {get; set;}
        public bool Elapsed => Data.Slot.RemainingTicks == 0;

        public Timer(int duration = 10) {
            Data = new TimerData { 
                Duration = duration, 
                RemainingTicks = duration,
                Slot = GameClock.NullSlot
            };
        }   

        public void Resume() => GameClock.Subscribe((ITimerType) this, Data.RemainingTicks);
        public void Pause() => GameClock.Unsubscribe((ITimerType) this);
        public void Begin() => GameClock.Subscribe((ITimerType) this, Data.Duration);
        public void End() => GameClock.Subscribe((ITimerType) this, 0);
    }
}