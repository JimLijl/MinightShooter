using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyCharacter : MonoBehaviour {

    private Animator e_Anim;
    private NavMeshAgent e_Nav;
    private EnemyAction e_Action;
    private AudioSource e_Audio;
    private CapsuleCollider e_Collider;
    private ParticleSystem e_Hit;
    private PlayerData p_Data;
    public AudioClip e_Clip;

    public float e_HP = 100;
    public int getScore = 10;
    public int Exp = 20;

	// Use this for initialization
	void Start () {
        e_Anim = GetComponent<Animator>();
        e_Action = GetComponent<EnemyAction>();
        e_Nav = GetComponent<NavMeshAgent>();
        e_Audio = GetComponent<AudioSource>();
        e_Collider = GetComponent<CapsuleCollider>();
        e_Hit = GetComponentInChildren<ParticleSystem>();
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (e_HP <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 1f);
            if (transform.position.y < -3)
            {
                Destroy(this.gameObject);
            }
        }
	}

    public void TakeHurt(float damage)
    {
        if (e_HP <= 0) return;
        e_Hit.Play();
        e_Audio.Play();
        e_HP -= damage;
        if(e_HP <= 0)
        {
            Dead();
        }

    }

    void Dead()
    {
        e_Anim.SetBool("isDeath",true);
        e_Nav.enabled = false;
        e_Collider.enabled = false;
        e_Action.enabled = false;
        AudioSource.PlayClipAtPoint(e_Clip, transform.position, 1);
        GameManager._intance.Score += getScore;
        p_Data.addExp(Exp);
    }
}
