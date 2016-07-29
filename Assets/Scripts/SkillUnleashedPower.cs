using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillUnleashedPower : MonoBehaviour {

    public GameObject SkillEffect;
    private Image Fill;
    private PlayerController p_Controller;
    private PlayerCharacter p_Character;
    private PlayerData p_Data;
    private AudioSource s_Audio;

    private float ColdTime = 15;
    private float SkillTime = 7;
    private float Timer = 0;
    private bool isUse = false;
    private bool Skill1Act = true;
    public bool undeadPower = false;
    private bool skillOpen = true;

    // Use this for initialization
    void Start () {
        s_Audio = GetComponent<AudioSource>();
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
        Fill = transform.Find("SkillFill3").GetComponent<Image>();
        p_Controller = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerController>();
        p_Character = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerCharacter>();
        SkillEffect.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        UnleashedPower();

        if (p_Data.Level < 10)
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

    void UnleashedPower()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (p_Data.Level >= 10 && p_Character.p_MP >35) {
                isUse = true;
                undeadPower = true;
                p_Controller.moveSpeed = 10;
                SkillEffect.SetActive(true);
                if (Skill1Act)
                {
                    s_Audio.Play();
                    p_Character.p_MP -= 35;
                    Skill1Act = false;
                }
            }
        }

        if (isUse)
        {
            Timer += Time.deltaTime;
            Fill.fillAmount = 1 - (Timer / ColdTime);
            
            if(Timer > SkillTime)
            {
                undeadPower = false;
                p_Controller.moveSpeed = 5;
                SkillEffect.SetActive(false);
            }

            if (Timer >= ColdTime)
            {
                Fill.fillAmount = 0;
                Timer = 0;
                isUse = false;
                Skill1Act = true;
            }
        }

        if (GameManager._intance.GameState == GameManager.GAMESTATE_END)
        {
            Timer = ColdTime;
        }
    }

}
