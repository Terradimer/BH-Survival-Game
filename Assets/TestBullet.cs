using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity
{
    [SerializeField]private Vector2 slope = new Vector2(1, 1);
    private Vector2 spawnPos;
    // Start is called before the first frame update
    void Enable()
    {
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector2.right) * speed/100;
    }

    public void SetTarget(Vector2 targetPosition){
        transform.right = (Vector3)targetPosition - transform.position;
    }
}
