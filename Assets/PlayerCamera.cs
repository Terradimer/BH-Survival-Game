using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
public Camera playerCam;
[Tooltip("Do not set below 1.")]
private float snappinessClose = 30;
private float snappinessFar = 5;

    // Update is called once per frame
    void Update()
    {
        // So this part is to just keep Z constant to what ever it was set to without messing with it.
        float prevZ = playerCam.transform.position.z;
        //Variable makes readable!
        float distance = Vector2.Distance(playerCam.transform.position,transform.position);
        //Math is fun, this is where the calculaton for the camera position is
        playerCam.transform.position += Mathf.Pow(distance, 1/snappinessClose ) * Time.deltaTime * Mathf.Pow(distance, snappinessFar) * (transform.position - playerCam.transform.position);
        //Put x back where it was
        playerCam.transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y, prevZ);
    }
}
