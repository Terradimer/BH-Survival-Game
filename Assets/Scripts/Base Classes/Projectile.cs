using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : EntityData {
    public float speed {get; set;}
    public int damage {get; set;}
    public Compendium.DamageType damageType {get; private set;}

    public Projectile (
        int dmg, Compendium.DamageType dtype = Compendium.DamageType.None, 
        float spd = float.NaN, Actor own = null ) {
            damage = dmg;
            damageType = dtype;

            speed = spd;
            holder = own;
    }
}
