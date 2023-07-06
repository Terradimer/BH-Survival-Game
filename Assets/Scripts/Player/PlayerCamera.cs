using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    private Camera playerCam;
    public float speed = 1;
    public Vector3 velocity = Vector3.zero, targetPos;
    public Transform player;
    //attach player movement
    public PlayerMovement playerMov;

    private void Awake() {
        //playerCam = Camera.main;
    }

    void LateUpdate()
    {
        // So this part is to just keep Z constant to what ever it was set to without messing with it.
        float prevZ = transform.position.z;

        Vector3 smoothPos = transform.position + (player.transform.position - transform.position) * 0.5f *playerMov.speed * Time.deltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, smoothPos, ref velocity, Time.deltaTime);
        //Put x back where it was
        transform.position = new Vector3(transform.position.x, transform.position.y, prevZ);
    }
}
