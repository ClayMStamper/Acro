using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHitbox : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {

        Debug.Log(name + ", hit: " + other.name);
        other.GetComponent<IGetHit>()?.OnHit(5);
        
    }
}

