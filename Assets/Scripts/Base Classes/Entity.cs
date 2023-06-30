using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public Vector2 position { 
        get { return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); }
    }
    //* NOTE: Speed is an Entity variable
    // TODO: The entity class which parents anything interacting on the map (Actors, Projectiles, ect)
}
