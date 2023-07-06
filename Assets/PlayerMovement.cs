using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Vector2 inputMovDir;
    private Controls controls;
    private InputAction input;
    private Vector2 momentum;
    
    public float speed = 8;
    private float momentumAcc = 0.05f;
    private float momentumDcc = 20;
    private float momenMax = 2;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Controls();
    }
    void OnEnable(){
       input = controls.playerActionMap.WASD; 
       input.Enable();
    }
    void OnDisable(){
        input.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        //read inputs
        inputMovDir = input.ReadValue<Vector2>();


        //momentum uptick
        momentum += momentumAcc * inputMovDir * speed * Time.deltaTime;
        
        //Move the player
        transform.position = transform.position + (new Vector3(momentum.x, momentum.y, 0)) + (new Vector3(inputMovDir.x, inputMovDir.y, 0) * speed * Time.deltaTime);
    
        // momentum down tick
        momentum -= momentum * momentumDcc * Time.deltaTime;

        //clamp down momentum so it doesnt get to out of hand
        momentum = new Vector2(Mathf.Clamp(momentum.x, -momenMax, momenMax), Mathf.Clamp(momentum.y, -momenMax, momenMax));
    }
}
