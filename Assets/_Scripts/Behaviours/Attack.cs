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
            if (_attack.MoveNext())
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

