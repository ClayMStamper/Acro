using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IRun {

    void Run(Transform transform);

}

public abstract class RunType : IRun {
    
    public float speed { get; private set; }
    public float acc { get; private set; }

    public RunType(float speed, float acc) {
        this.speed = speed;
        this.acc = acc;
    }
        
    public void Run(Transform transform) {

        if (GetInput.Forward()) {
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (GetInput.Back()) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        
    }
}

public class RunNormal : RunType {
    
    public RunNormal(float speed, float acc) : base(speed, acc) {
        
    }
    
}

