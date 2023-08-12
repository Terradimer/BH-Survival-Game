using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Compendium.GameData;
public class Enemy : Actor {
    public Delegate Behavior;
    public Delegate Attack;
    public SpriteRenderer Renderer;

    // TODO: Add the GetTarget function (will be a Func<>, but should have a default)
    // TODO: Add the Cache function (disables the enemy and adds them to the enemy cache)
    // TODO: fully impliment the SetTo function

    public Enemy SetTo(Enemy other) {
        // Replace the other stuff too, and generally reset the object
        this.maxHP = other.maxHP;
        this.currentHP = this.maxHP;
        this.Behavior = other.Behavior;
        this.Attack = other.Attack;

        // You can't just replace the sprite, instead we need to change its animation component
        // but that can come later when we have animated sprites
        this.Renderer.sprite = other.Renderer.sprite;
        return this;
    }

    protected override void Awake() {
        // Testing left over from Amani's settup
        base.Awake();
           // Timer x = new Timer(15, false);
           // x.OnTimerEnd += () => {Destroy(gameObject);};
    }

    protected override void RemoveRefs() {
        base.RemoveRefs();
        Entities.Enemies.Remove(this);
    }

    protected override void AddRefs() {
        base.AddRefs();
        Entities.Enemies.Add(this);
    }
}
