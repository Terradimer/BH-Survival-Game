using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharater : Actor
{
    //The hope is that here is where all the player's scripts can be refrenced and is a hub for all the player's information
    public PlayerMovement playerMove;
    public PlayerCamera playerCam;
    void Start()
    {
        playerCam = GetComponent<PlayerCamera>();
        playerMove = GetComponent<PlayerMovement>();
    }

}
