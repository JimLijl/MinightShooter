using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillFinalVent : MonoBehaviour {

    private GameObject SkillEffect;
    private PlayerCharacter p_Character;
    private Image Fill;
    private FinalAttack FinalShoot1;
    private FinalAttack FinalShoot2;
    private FinalAttack FinalShoot3;
    private FinalAttack FinalShoot4;
    private FinalAttack FinalShoot5;
    private GameObject[] finalShoot;
    private SkillUnleashedPower s_UnleashedPower;
    private PlayerData p_Data;
    private AudioSource s_Audio;

    private float ColdTime = 40;
    private float Timer = 0;
    private bool isUse = false;
    private bool isShoot = true;
    private bool Skill1Act = true;
    private bool skillOpen = true;

    // Use this for initialization
    void Start () {
        s_Audio = GetComponent<AudioSource>();
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
        s_UnleashedPower = GameObject.FindGameObjectWithTag(Tags.UnleashedPower).GetComponent<SkillUnleashedPower>();
        Fill = transform.Find("SkillFill4").GetComponent<Image>();
        finalShoot = GameObject.FindGameObjectsWithTag(Tags.FinalShoot);
        FinalShoot1 = finalShoot[0].GetComponentInChildren<FinalAttack>();
        FinalShoot2 = finalShoot[1].GetComponentInChildren<FinalAttack>();
        FinalShoot3 = finalShoot[2].GetComponentInChildren<FinalAttack>();
        FinalShoot4 = finalShoot[3].GetComponentInChildren<FinalAttack>();
        FinalShoot5 = finalShoot[4].GetComponentInChildren<FinalAttack>();
        SkillEffect = GameObject.FindGameObjectWithTag(Tags.FinalEffect);
        p_Character = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerCharacter>();
        SkillEffect.SetActive(false);

        for (int i = 0; i < finalShoot.Length; i++)
        {
            finalShoot[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update () {
        FinalVent();
        if(p_Data.Level < 15)
        {
            Fill.fillAmount = 1;
        }else
        {
            if (skillOpen)
            {
                Fill.fillAmount = 0;
                skillOpen = false;
            }
        }

    }

    void FinalVent()
    {

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (p_Data.Level >= 15 && p_Character.p_MP > 50)
            {
                isUse = true;
                if (Skill1Act)
                {
                    p_Character.p_MP -= 50;
                    Skill1Act = false;
                }
            }
        }

        if (isUse && isShoot)
        {
            s_Audio.Play();
            SkillEffect.SetActive(true);
            s_UnleashedPower.undeadPower = true;
            Invoke("EffectOver", 6.5f);
            Invoke("ShowGun", 0.5f);
            Invoke("Shoot", 5f);
            Invoke("SkillOver", 6f);
            isShoot = false;
        }

        if (isUse)
        {
            Timer += Time.deltaTime;
            Fill.fillAmount = 1 - (Timer / ColdTime);
            if (Timer >= ColdTime)
            {
                Fill.fillAmount = 0;
                Timer = 0;
                isUse = false;
                isShoot = true;
            }

            
        }

        if (GameManager._intance.GameState == GameManager.GAMESTATE_END)
        {
            Timer = ColdTime;
        }
    }

    void EffectOver()
    {
        SkillEffect.SetActive(false);
        s_UnleashedPower.undeadPower = false;
    }
    
    void ShowGun()
    {
        for (int i = 0; i < finalShoot.Length; i++)
        {
            finalShoot[i].SetActive(true);

        }
    }

    void Shoot()
    {
        FinalShoot1.Attack();
        FinalShoot2.Attack();
        FinalShoot3.Attack();
        FinalShoot4.Attack();
        FinalShoot5.Attack();
    }

    void SkillOver()
    {
        for (int i = 0; i < finalShoot.Length; i++)
        {
            finalShoot[i].SetActive(false);
        }
    }
}
