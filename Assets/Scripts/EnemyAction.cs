using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {

    private Transform p_Pos;

    private NavMeshAgent e_Nav;
    private Animator e_Anim;

	// Use this for initialization
	void Start () {
        p_Pos = GameObject.FindGameObjectWithTag("Player").transform;
        e_Nav = GetComponent<NavMeshAgent>();
        e_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING)
        {
            if (Vector3.Distance(transform.position, p_Pos.position) > 1.5f)
            {

                e_Nav.SetDestination(p_Pos.position);
                e_Nav.Resume();
                e_Anim.SetBool("isMove", true);
            }
            else
            {
                e_Nav.Stop();
                e_Anim.SetBool("isMove", false);
            }

        }
    }
}
