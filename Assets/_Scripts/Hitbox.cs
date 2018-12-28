using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHit {void OnHit();}
public interface IGetHit {void OnHit();}

public abstract class WeaponHitbox : MonoBehaviour, IHit
{
    public void OnHit() {
            
    }
    
}
