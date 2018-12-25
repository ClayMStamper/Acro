using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump {
    void Jump();
}
    
public abstract class JumpType : IJump {

    private readonly Transform _transform;
    private readonly Vector3 _force;

    //defaulted to force of gravity
    private readonly Vector3 acceleration = new Vector3(0, -10, 0);

    protected JumpType(Transform transform, int force) {
        this._force = new Vector3(0,force,0);
        this._transform = transform;
    }
    
    public void Jump() {

        Vector3 velocity = acceleration;
        
        if (GetInput.Up()) {
            velocity += _force;
        }
        
        _transform.Translate(velocity * Time.deltaTime);
        
    }
        
}

public class JumpNormal : JumpType {
    public JumpNormal(Transform transform, int force) : base(transform, force) { }
}
    
    
