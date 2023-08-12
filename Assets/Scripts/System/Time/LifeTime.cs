using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTime {
    public interface ILifeTime {
        LifeTime Time {get; set;}
        void OnEnd();
    }

    public struct LifeTimeData : ITimerData {
        public int Duration {get; set;}
        public int RemainingTicks {get; set;}
        public TimeSlot Slot {get; set;} 
        public ILifeTime Target;

        public bool Equals(TimerData other) =>
            Duration == other.Duration && RemainingTicks == other.RemainingTicks;
        
        public override int GetHashCode() =>
            17 * (23 + Duration.GetHashCode()) * (23 + RemainingTicks.GetHashCode());
    }

    public class LifeTime : ITimerType {
        public ITimerData Data {get; set;}
        public bool Elapsed => Data.Slot.RemainingTicks == 0;
        
        public LifeTime(ILifeTime t, int duration) {
            Data = new LifeTimeData { 
                Duration = duration, 
                RemainingTicks = duration,
                Slot = GameClock.NullSlot,
                Target = t
            };
        }

        public static T AsLifeTime<T>(T target, int duration) {
            if (target is ILifeTime targetlifetime)
                targetlifetime.Time = new LifeTime(targetlifetime, duration);
            return target;
        }

        public void Resume() => GameClock.Subscribe((ITimerType) this, Data.RemainingTicks);
        public void Pause() => GameClock.Unsubscribe((ITimerType) this);
        public void Begin() => GameClock.Subscribe((ITimerType) this, Data.Duration);
        public void End() => GameClock.Subscribe((ITimerType) this, 0);
    }
}
