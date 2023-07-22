using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// The entity class  parents anything interacting on the map (Actors, Projectiles, ect)
public class Entity : MonoBehaviour {
    public Vector2 position => new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); 
    public float speed {get; set;}
}
