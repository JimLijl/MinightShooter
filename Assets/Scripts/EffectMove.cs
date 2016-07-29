using UnityEngine;
using System.Collections;

public class EffectMove : MonoBehaviour {

    private float MoveSpeed = 15;
    private float Attack = 500;
    private float Timer;

    void Update()
    {
        
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer > 6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.enemy)
        {
            other.GetComponent<EnemyCharacter>().TakeHurt(Attack);
        }
    }
    
}
