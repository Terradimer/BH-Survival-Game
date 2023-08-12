using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Damage {
    [Flags]
    public enum DamageType {
        None = 0,
        Energy = 1 << 0,
        Balistic = 1 << 1,
        Fire = 1 << 2
    }

    public struct DamageInstance {
        public float amount {get; set;}
        public DamageType damageType {get; private set;}

        public DamageInstance(float amount, params DamageType[] dtypes) {
            this.amount = amount;
            damageType = DamageType.None;
            
            foreach (var dtype in dtypes) damageType |= dtype;
        }

        public bool ContainsAny(params DamageType[] dtypes) {
            foreach (var type in dtypes)
                if ((damageType & type) == type)
                    return true;
            
            return false;
        }

        public bool ContainsAll(params DamageType[] dtypes) {
            foreach (var dtype in dtypes)
                if ((damageType & dtype) != dtype)
                    return false;
            
            return true;
        }
    }
}
