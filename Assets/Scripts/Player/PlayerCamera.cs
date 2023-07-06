using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    private Camera playerCam;
    public float speed = 1;
    public Vector3 velocity = Vector3.zero, targetPos;

    private void Awake() {
        playerCam = Camera.main;
    }

    void LateUpdate() {
        targetPos = new Vector3(transform.position.x, transform.position.y, playerCam.transform.position.z);
        playerCam.transform.position = Vector3.SmoothDamp(playerCam.transform.position, targetPos, ref velocity, speed * Time.deltaTime);
    }
}
