using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    private void enableAttackCollider()
    {
        this.weapon.GetComponent<Collider>().enabled = true;
    }
    private void disableAttackCollider()
    {
        this.weapon.GetComponent<Collider>().enabled = false;
    }
    private void attacksound() {
        AudioSource hit = GetComponent<AudioSource>();
        if (null == hit) return;
        hit.Play();
    }
}
