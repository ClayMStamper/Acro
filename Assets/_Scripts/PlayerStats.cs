using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IGetHit {

    public Stat damage;
    public Stat armor;
    public Stat jumpForce;
    public Stat speed;
    public Stat health;

    public int currentHealth { get; private set; }

    public void OnHit(int rawDamage) {
        int damage = Mathf.Clamp (rawDamage - armor.GetValue(), 0, int.MaxValue); //damage after armor
        currentHealth -= damage;
    }

    private void Die() {
        
    }

}
