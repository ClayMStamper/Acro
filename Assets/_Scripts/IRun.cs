using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IRun {

    void Run(Transform transform);

}

public abstract class RunType : IRun {
    
    private Vector3 velocity;

    private Transform _transform;
    private readonly float _speed;
    private float _acc;

    protected RunType(Transform transform, float speed, float acc) {
        this._speed = speed;
        this._acc = acc;
    }
        
    public void Run(Transform transform) {

        if (GetInput.Forward()) {
            
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }

        if (GetInput.Back()) {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
        
    }
}

public class RunNormal : RunType {
    
    public RunNormal(Transform transform, float speed, float acc) : base(transform, speed, acc) {}
    
}

