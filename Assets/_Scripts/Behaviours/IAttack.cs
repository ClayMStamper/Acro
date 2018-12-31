using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack {void Attack();}
public interface IGetHit {void OnHit(int rawDamage);}

public abstract class LightAttackType : IAttack {

    protected readonly Animator anim;

    public IEnumerator attack { get; private set; }
    
    protected LightAttackType(Animator anim) {
        this.anim = anim;
    }
    
    public void Attack() {

        if (attack != null)
            if (attack.MoveNext())
                return;
        
        if (GetInput.ForwardLight())
            attack = FLight();
        if(GetInput.UpLight())
            attack = UpLight();
        if(GetInput.DownLight())
            attack = DownLight();
        
    }

    protected abstract IEnumerator FLight();
    protected abstract IEnumerator UpLight();
    protected abstract IEnumerator DownLight();

}

