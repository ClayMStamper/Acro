using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Extensions;


public interface IRun { void Run();}

public abstract class RunType : IRun {
    
    private Vector3 _velocity;

    private readonly Transform _transform;
    private readonly Animator _anim;
    private readonly float _speed;
    private readonly float _acc;

    protected RunType(Transform transform, float speed, float acc, Animator anim) {
        this._transform = transform;
        this._speed = speed;
        this._acc = acc;
        this._anim = anim;
    }

    public void Run() {
        
        Accelerate();
        Animate();
        Move();
        
    }
    
    private void Accelerate() {

        if (GetInput.Forward()) {
            float xVelocity = Mathf.Clamp(_velocity.x + _acc * Time.deltaTime, 0, _speed);
            _velocity = _velocity.WithValues(x: xVelocity);
        } else if (GetInput.Back()) {
            float xVelocity = Mathf.Clamp(_velocity.x - _acc * Time.deltaTime, -_speed, 0);
            _velocity = _velocity.WithValues(x: xVelocity);
        }
        else {
            _velocity = _velocity.Lerp(Vector3.zero, Time.deltaTime * 3);
        }
                
    }

    private void Animate() {
        _anim.SetFloat("Speed",_velocity.x);
        if (_velocity.x > 0)
            _anim.SetBool("FaceRight", true);
        else 
            _anim.SetBool("FaceRight", false);

    }
    
    private void Move() {
        _transform.Translate(_velocity * Time.deltaTime);
    }
    
}

public class RunNormal : RunType {
    
    public RunNormal(Transform transform, float speed, float acc, Animator anim) : base(transform, speed, acc, anim) {}
    
}

