using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private LightAttackType _lightAttack;

    private void Start() {
        _lightAttack = new FistLight(GetComponent<Animator>());
    }

    private void Update() {
        _lightAttack.Attack();
    }
}
