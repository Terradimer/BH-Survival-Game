using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseEnemy : Actor
{
    public SpwaningArea sArea;
    [SerializeField] private int ticker;
    public BaseEnemy Overload(string type){
        Debug.Log("Called from Actor: " + type);
        
        Action<GameObject> doTing = new Action<GameObject>(Compendium.GetSAction(type));
        doTing.DynamicInvoke(this.gameObject);
        return this;
    }

    public override void OnTick(){
        base.OnTick();
        ticker++; 
        if(ticker > 15){
            ProperDeath();
        }
    }

    private void ProperDeath(){
        Game.onTickUpdate -= OnTick;
        sArea.deManafest(this.gameObject);
    }
}
