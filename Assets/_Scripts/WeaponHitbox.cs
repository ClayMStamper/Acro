using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetHit {void OnHit(int rawDamage);}

public class WeaponHitbox : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {

        other.GetComponent<IGetHit>()?.OnHit(5);
        
    }
}

