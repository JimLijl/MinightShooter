using UnityEngine;
using System.Collections;

public class FinalAttack : MonoBehaviour {

    public GameObject AttackEffect;
    
	public void Attack()
    {
        Instantiate(AttackEffect,transform.position,transform.rotation);
    }
}
