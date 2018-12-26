using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump {
    void FallOrJump();
    Vector3 Jump(Vector3 vel);
    void CheckIfLanded(Transform platform);
}
    
public abstract class JumpType : IJump {

    private readonly Transform _transform;
    private readonly Rigidbody _rb;
    private readonly Vector3 _force;
    private readonly int _maxJumps;

    private int _jumps = 0;

    //defaulted to force of gravity
    private readonly Vector3 _acceleration = new Vector3(0, -10, 0);

    protected JumpType(Transform transform, Rigidbody rb, float force, int maxJumps) {
        _force = new Vector3(0,force,0);
        _transform = transform;
        _rb = rb;
        _maxJumps = maxJumps;
    }
    
    public void FallOrJump() {

        Vector3 velocity = Jump(_acceleration);
        _rb.AddForce(velocity);
        
    }

    //adds _force to velocity
    public Vector3 Jump(Vector3 acc) {
        
        if (_jumps >= _maxJumps)
            return acc;
        
        if (GetInput.Up()) {
            _jumps++;
            _rb.velocity = Vector3.zero;
            return acc + _force;
        }

        return acc;

    }

    //land back on the ground
    public void CheckIfLanded(Transform platform) {
        
        // not a platform
        if (platform.gameObject.layer != 9)
            return; 
        
        //below platform
        if (platform.position.y - _transform.position.y > 0)
            return;

        OnLanded();

    }

    private void OnLanded() {
        _jumps = 0;
    }
    
}

public class JumpNormal : JumpType {
    public JumpNormal(Transform transform, Rigidbody rb, float force, int maxJumps) : base(transform, rb, force, maxJumps) { }
}
    
    
