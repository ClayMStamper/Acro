using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump {
    void Jump();
}
    
public abstract class JumpType : IJump {

    private readonly Transform _transform;
    private readonly Rigidbody _rb;
    private readonly Vector3 _force;

    //defaulted to force of gravity
    private readonly Vector3 acceleration = new Vector3(0, -10, 0);

    protected JumpType(Transform transform, Rigidbody rb, int force) {
        _force = new Vector3(0,force,0);
        _transform = transform;
        _rb = rb;
    }
    
    public void Jump() {

        Vector3 velocity = acceleration;
        
        if (GetInput.Up()) {
            velocity += _force;
        }
        
        _rb.AddForce(velocity);
        
    }
        
}

public class JumpNormal : JumpType {
    public JumpNormal(Transform transform, Rigidbody rb, int force) : base(transform, rb, force) { }
}
    
    
