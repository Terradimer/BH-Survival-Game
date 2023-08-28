using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestPrimary : AbilityClass
{
    public GameObject bulletPreFab; 
    public Vector2 mPos;

    override public AbilityClass Cast(Component target){
        mPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Instantiate(bulletPreFab, transform.position, transform.rotation).GetComponent<Bullet>()
        .SetTarget(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        return this;
    }
}
