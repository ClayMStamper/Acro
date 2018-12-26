using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack {void Attack();}

public abstract class LightAttackType : IAttack {

    protected readonly Animator _anim;

    private IEnumerator _attack;
    
    protected LightAttackType(Animator anim) {
        _anim = anim;
    }
    
    public void Attack() {

        if (_attack != null)
            if (!_attack.MoveNext())
                return;
        
        if (GetInput.ForwardLight())
            _attack = FLight();
        if(GetInput.UpLight())
            _attack = UpLight();
        if(GetInput.DownLight())
            _attack = DownLight();
        
    }

    protected abstract IEnumerator FLight();
    protected abstract IEnumerator UpLight();
    protected abstract IEnumerator DownLight();

}

public abstract class SpecialAttackType : IAttack {

    public void Attack() {
        
    }
    
}

public class Fist_Light : LightAttackType {
    
    public Fist_Light(Animator anim) : base(anim) { }
    
    protected override IEnumerator FLight() {
        
        Debug.Log("Forward Light: Punching");
        _anim.SetTrigger("Punch");

        do {
            yield return null;
        } while (_anim.GetComponent<Animation>().isPlaying);
        
    }

    protected override IEnumerator UpLight() {
        yield return null;
    }

    protected override IEnumerator DownLight() {
        yield return null;
    }

}