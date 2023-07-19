using System.Collections.Generic;
using UnityEngine;
using System;

public static class Compendium {
    private static CompendiumContainer container = GameObject.Find("CompendiumContainer").GetComponent<CompendiumContainer>();
    private static Dictionary<string,Action> Summonables = new Dictionary<string,Action>(){
        {"Test", new Action(() => {
            CompendiumContainer container = GameObject.Find("CompendiumContainer").GetComponent<CompendiumContainer>();
            UnityEngine.Object.Instantiate(container.GetPrefab("Test"),Vector3.zero, Quaternion.identity);
            UnityEngine.Debug.Log("Test is my name");
        })}
    };
    public enum DamageType {None, Energy, Balistic, Fire, Ect}
    private static Dictionary<string, Effect> _effects_ = new Dictionary<string, Effect>() {
        {"Burning", new Effect()
            .HookTo(
                Actor.getHook.OnTick,
                new Action<Actor>((Actor actor) => {
                    actor.ApplyDamage(new DamageInstance(4, DamageType.Fire));
                    Debug.Log(actor.currentHP);
                }))
            .SetTicksPerEffectProck(5)
            .SetDuration(30)
        },
        {"Fire_Resistance", new Effect()
            .HookTo(
                Actor.getHook.ApplyDamage,
                new Action<DamageInstance>((DamageInstance p) => {
                    if (p.damageType == DamageType.Fire) p.damage /= 2;
                })
            )
        }
    };

    /// <summary>
    /// Returns an Effect object based on a given key, or null if the key is
    /// not found in the Effects dictionary.
    /// </summary>
    /// <param name="key">The key parameter is a string that represents the key of the effect that we
    /// want to retrieve from the dictionary.</param>
    /// <returns>
    /// Returns an Effect object.
    /// </returns>
    public static Effect GetEffect(string key) {
        if(!_effects_.ContainsKey(key)) return null;
        return _effects_[key];
    }

        public static Action GetSAction(string key) {
        if(Summonables.ContainsKey(key)) return Summonables[key];
        UnityEngine.Debug.Log("big bad at compeduim");
        return null;
    }
}

