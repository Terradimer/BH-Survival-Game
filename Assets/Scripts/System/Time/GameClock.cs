using System;
using Unity.Jobs;
using Unity.Burst;
using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;

namespace GameTime {
    public class GameClock : MonoBehaviour {
        // TODO: Adjust TICK_TIMER_MAX to make game speed feel better (the smaller the number the more ticks/second)
        private const float TICK_TIMER_MAX = .2f;
        public static TimeSlot NullSlot = new TimeSlot() {RemainingTicks = 0, TData = null};
        private static Dictionary<int, TimeSlot> _timerManager = new Dictionary<int, TimeSlot>();

        public static event Action OnTickUpdate;

        private static float tickTimer, cachedTimeScale;
        public static bool paused {get; private set;}

        public static void Subscribe(ITimerType timer, int timeSlotIndex) {
            if(timer == null) return;
            if(!_timerManager.ContainsKey(timeSlotIndex)) 
                _timerManager.Add(timeSlotIndex, new TimeSlot(timeSlotIndex));

            TimeSlot slot = _timerManager[timeSlotIndex];

            if(!slot.TData.ContainsKey((ITimerData)timer.Data)) 
                slot.TData.Add((ITimerData)timer.Data, new TDataBatch() {count = 0, instance = timer.Data});
            
            timer.Data = slot.TData[(ITimerData)timer.Data].instance;
            slot.TData[(ITimerData)timer.Data].count ++;
            timer.Data.Slot = _timerManager[timeSlotIndex];
        }

        public static void Unsubscribe(ITimerType timer) {
            if(timer.Data.Slot.TData == null) return;
            TimeSlot slot = timer.Data.Slot;

            slot.TData[(ITimerData)timer.Data].count --;
            if(slot.TData[(ITimerData)timer.Data].count <= 0) 
                slot.TData.Remove((ITimerData)timer.Data);

            if(_timerManager[slot.RemainingTicks].TData.Count <= 0)
                _timerManager.Remove(slot.RemainingTicks);

            timer.Data = new TimerData() {
                Duration = timer.Data.Duration,
                RemainingTicks = slot.RemainingTicks
            };
            timer.Data.Slot = NullSlot;
        }

        public static int SecondsToTicks(int seconds) => (int) (seconds / TICK_TIMER_MAX);
        
        public static void TogglePause(bool toggle) {
            if (toggle == paused) return;
            paused = toggle;

            if(paused == false) {
                Time.timeScale = cachedTimeScale;
                return;
            }

            cachedTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void Update() {
            tickTimer += Time.deltaTime;
            if(tickTimer >= TICK_TIMER_MAX) {
                tickTimer -= TICK_TIMER_MAX;
                UpdateTimers();
                if (OnTickUpdate != null) OnTickUpdate();
            }
        }

        void UpdateTimers() {
            if(_timerManager.ContainsKey(0)) {
                foreach(var i in _timerManager[0].TData.Values) {
                    if(i.instance is LifeTimeData lt) lt.Target.OnEnd();
                    i.instance.RemainingTicks = 0;
                    i.instance.Slot = NullSlot;
                }
                _timerManager.Remove(0);
            }
            
            var newTimerManager = new Dictionary<int, TimeSlot>();
            foreach (var kvp in _timerManager) newTimerManager[kvp.Key - 1] = kvp.Value;
            
            _timerManager = newTimerManager;
        }
    }

    public struct TimeSlot {
        public int RemainingTicks {get; set;}
        public Dictionary<ITimerData, TDataBatch> TData {get; set;}

        public TimeSlot(int slot) {
            RemainingTicks = slot;
            TData = new Dictionary<ITimerData, TDataBatch>();
        }
    }

    public class TDataBatch {
        public int count {get; set;}
        public ITimerData instance {get; set;}
    }

    public interface ITimerData : IEquatable<TimerData> {
        TimeSlot Slot {get; set;}
        int Duration {get; set;}
        int RemainingTicks {get; set;}
    }

    public interface ITimerType {
        ITimerData Data {get; set;}
    }
}