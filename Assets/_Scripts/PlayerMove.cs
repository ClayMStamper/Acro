using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    
    private IRun _run;
    private IJump _jump;

    private void Start() {
        _run = new RunNormal(2, .1f);
        _jump = new JumpNormal(transform, 15);
    }
    
    private void Update() {
        _run.Run(transform);
        _jump.Jump();
    }
}
