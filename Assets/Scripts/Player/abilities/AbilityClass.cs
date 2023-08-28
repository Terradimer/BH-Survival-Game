using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityClass : MonoBehaviour
{
    virtual public AbilityClass Cast(Component target){
        print("!Ability! " + this.name);
        return this;
    }
}
