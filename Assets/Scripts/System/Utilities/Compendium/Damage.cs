using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Compendium.Damage {
    public enum DamageType {
        None, Energy, Balistic, Fire, Ect
    }

    public struct DamageInstance {
        public int damage {get; set;}
        public DamageType damageType {get; private set;}

        public DamageInstance ( int dmg, DamageType dtype = DamageType.None, Actor own = null ) {
            damage = dmg;
            damageType = dtype;
        }
    }
}
