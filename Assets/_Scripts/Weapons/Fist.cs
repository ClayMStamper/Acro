using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistItem : Equipment {
    
}

public class FistLight : LightAttackType {
    
    public FistLight(Animator anim) : base(anim) { }
    
    protected override IEnumerator FLight() {

        anim.SetBool("Punch", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(1).length);
        anim.SetBool("Punch", false);

    }

    protected override IEnumerator UpLight() {

        anim.SetBool("Uppercut", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(1).length);
        anim.SetBool("Uppercut", false);


    }

    protected override IEnumerator DownLight() {
        yield return null;
    }

}
