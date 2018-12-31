using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistItem : Equipment {
    
}

public class FistLight : LightAttackType {
    
    public FistLight(Animator anim) : base(anim) { }
    
    protected override IEnumerator FLight() {

        _anim.SetBool("Punch", true);
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(1).length);
        _anim.SetBool("Punch", false);

    }

    protected override IEnumerator UpLight() {

        _anim.SetBool("Uppercut", true);
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(1).length);
        _anim.SetBool("Uppercut", false);


    }

    protected override IEnumerator DownLight() {
        yield return null;
    }

}
