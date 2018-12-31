using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IGetHit {
    
    [SerializeField]
    protected int _hitPoints;

    protected bool isBeingHit;
    
    public void OnHit(int rawDamage) {

        Debug.Log("Hit for: " + rawDamage + " damage");
        
        _hitPoints -= rawDamage;
        Debug.Log("New HP: " + _hitPoints);
        
        if (_hitPoints <= 0)
            Die();
        
    }

    private void Die() {
        Destroy(gameObject);
    }
    
}
