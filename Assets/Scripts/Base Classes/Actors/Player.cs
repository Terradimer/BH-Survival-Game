using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Compendium.GameData;

public class Player : Actor {
    protected override void RemoveRefs() {
        base.RemoveRefs();
        Entities.Players.Remove(this);
    }

    protected override void AddRefs() {
        base.AddRefs();
        Entities.Players.Add(this);
    }
}
