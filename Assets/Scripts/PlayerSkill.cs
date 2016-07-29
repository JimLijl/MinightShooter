using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour {

    public GameObject Skill1;
    public GameObject Skill2;
    private GameObject GunEnd1;
    public GameObject GunEnd2;
    public GameObject GunEnd3;
    public GameObject GunEnd4;
    public GameObject GunEnd5;
    public GameObject GunEnd6;
    public GameObject GunEnd7;
    private LineRenderer shootLine1;
    private LineRenderer shootLine2;
    private LineRenderer shootLine3;
    private LineRenderer shootLine4;
    private LineRenderer shootLine5;
    private LineRenderer shootLine6;
    private LineRenderer shootLine7;
    private Image Skill1Fill;
    private PlayerShoot p_Shoot1;
    private PlayerShoot p_Shoot2;
    private PlayerShoot p_Shoot3;
    private PlayerShoot p_Shoot4;
    private PlayerShoot p_Shoot5;
    private PlayerShoot p_Shoot6;
    private PlayerShoot p_Shoot7;
    private PlayerCharacter p_Character;
    private SkillScattering skillScattering;
    

    private float s1_ColdTime = 2;   
    private float Timer;
    private bool Skill1Act = true;
    private bool isUse = false;

    
    void Start()
    {
        
        Skill1Fill = Skill1.transform.Find("SkillFill1").GetComponent<Image>();
        p_Shoot1 = GetComponentInChildren<PlayerShoot>();
        skillScattering = Skill2.GetComponent<SkillScattering>();
        p_Character = GetComponent<PlayerCharacter>();
        GunEnd1 = GameObject.FindGameObjectWithTag(Tags.OriGunEnd);
        shootLine1 = GunEnd1.GetComponent<Renderer>() as LineRenderer;
        shootLine2 = GunEnd2.GetComponent<Renderer>() as LineRenderer;
        shootLine3 = GunEnd3.GetComponent<Renderer>() as LineRenderer;
        shootLine4 = GunEnd4.GetComponent<Renderer>() as LineRenderer;
        shootLine5 = GunEnd5.GetComponent<Renderer>() as LineRenderer;
        shootLine6 = GunEnd6.GetComponent<Renderer>() as LineRenderer;
        shootLine7 = GunEnd7.GetComponent<Renderer>() as LineRenderer;
        p_Shoot2 = GunEnd2.GetComponentInChildren<PlayerShoot>();
        p_Shoot3 = GunEnd3.GetComponentInChildren<PlayerShoot>();
        p_Shoot4 = GunEnd4.GetComponentInChildren<PlayerShoot>();
        p_Shoot5 = GunEnd5.GetComponentInChildren<PlayerShoot>();
        p_Shoot6 = GunEnd6.GetComponentInChildren<PlayerShoot>();
        p_Shoot7 = GunEnd7.GetComponentInChildren<PlayerShoot>();
        
    }

    void Update()
    {
        
        ReinforceFirepower();
       
    }

    void ReinforceFirepower()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isUse = true;
            if (Skill1Act)
            {
                

                if (skillScattering.isScatteringOn)
                {
                    p_Shoot2.Attack = 120;
                    p_Shoot3.Attack = 120;
                    p_Shoot4.Attack = 120;
                    p_Shoot5.Attack = 120;
                    p_Shoot6.Attack = 120;
                    p_Shoot7.Attack = 120;
                    shootLine2.material.color = Color.red;
                    shootLine3.material.color = Color.red;
                    shootLine4.material.color = Color.red;
                    shootLine5.material.color = Color.red;
                    shootLine6.material.color = Color.red;
                    shootLine7.material.color = Color.red;
                    p_Character.p_MP -= 12;

                }
                else
                {
                    p_Character.p_MP -= 2;
                    p_Shoot1.Attack = 120;
                    shootLine1.material.color = Color.red;
                    
                }

                Skill1Act = false;
            }
        }

        if (isUse)
        {
            Timer += Time.deltaTime;
            Skill1Fill.fillAmount = 1 - (Timer / s1_ColdTime);
            if (Timer >= s1_ColdTime)
            {
                Skill1Fill.fillAmount = 0;
                Timer = 0;
                isUse = false;
                Skill1Act = true;
            }
            
        }

        if (GameManager._intance.GameState == GameManager.GAMESTATE_END)
        {
            Timer = s1_ColdTime;
        }
    }
	
}
