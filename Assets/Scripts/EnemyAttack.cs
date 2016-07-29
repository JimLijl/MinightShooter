using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private SkillUnleashedPower Skill3;
    private PlayerCharacter p_Character;
    private EnemyCharacter e_Character;

    public float attack = 10;
    public float attackTime = 1;
    private float Timer;


    // Use this for initialization
    void Start()
    {
        p_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        Skill3 = GameObject.FindGameObjectWithTag(Tags.UnleashedPower).GetComponent<SkillUnleashedPower>();
        e_Character = GetComponent<EnemyCharacter>();
        Timer = attackTime;
    }

    public void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player" && e_Character.e_HP > 0)
        {
            Timer += Time.deltaTime;
            if (Timer >= attackTime)
            {

                if (Skill3.undeadPower)
                {
                    p_Character.takeHurt(0);
                }
                else
                {
                    p_Character.takeHurt(attack);
                }
                Timer -= attackTime;
            }

        }
    }
}
