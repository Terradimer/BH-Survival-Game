using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour {
    public Vector2 inputMovDir;
    private Controls controls;
    private InputAction input;
    private Vector2 momentum;
    
    public float speed = 8f, momentumAcc = 0.05f, momentumDcc = 20f, momentumMax = 2f;

    void Awake() { controls = new Controls(); }

    void OnEnable() { controls.playerActionMap.WASD.Enable(); }

    void OnDisable() { controls.playerActionMap.WASD.Disable(); }

    void Update() {
        inputMovDir = controls.playerActionMap.WASD.ReadValue<Vector2>();

        Vector2 momentumItter = momentumAcc * inputMovDir * speed * Time.deltaTime * 0.5f;
        bool momentumLessThanMax = Mathf.Abs(momentum.x) < momentumMax && Mathf.Abs(momentum.y) < momentumMax;

        if(momentumLessThanMax) momentum = Vector2.ClampMagnitude(momentum + momentumItter, momentumMax);
        transform.position = transform.position + (Vector3)momentum + (Vector3)inputMovDir * speed * Time.deltaTime;
        if(momentumLessThanMax) momentum = Vector2.ClampMagnitude(momentum + momentumItter, momentumMax);

        momentum -= momentum * momentumDcc * Time.deltaTime;
    }
}