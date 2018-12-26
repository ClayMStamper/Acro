using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 2;
    public float acceleration = 0.01f;
    public float jumpForce = 500;
    
    public int maxJumps = 3;
    
    private RunType _run;
    private JumpType _jump;

    private void Start() {
        
        _run = 
            new RunNormal(transform, 
            speed: speed, 
            acc: acceleration);
        
        _jump = 
            new JumpNormal(transform, 
            GetComponent<Rigidbody>(), 
            force: jumpForce, 
            maxJumps: maxJumps);
        
    }
    
    private void Update() {
        _run.Run();
        _jump.FallOrJump();
    }

    private void OnCollisionEnter(Collision other) {
        
        Debug.Log("Colliding with: " + other.gameObject.name);
        
        //check if other is the ground
        _jump.CheckIfLanded(other.transform);
        
    }
}
