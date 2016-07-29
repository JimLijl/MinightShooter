using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillScattering : MonoBehaviour {

    private PlayerData p_Data;
    private PlayerCharacter p_Character;
    private GameObject OriGunEnd;
    public GameObject[] GunEnd;
    private Image Fill;

    private float ColdTime = 6;
    private float SkillTime = 3;
    private float Timer = 0;
    private bool isUse = false;
    public bool isScatteringOn = false;
    private bool Skill1Act = true;
    private bool skillOpen = true;

    // Use this for initialization
    void Start () {
        p_Character = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerCharacter>();
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
        GunEnd = GameObject.FindGameObjectsWithTag(Tags.GunEnd);
        OriGunEnd = GameObject.FindGameObjectWithTag(Tags.OriGunEnd);
        for (int i = 0; i < GunEnd.Length; i++)
        {
            GunEnd[i].SetActive(false);
        }
        Fill = transform.Find("SkillFill2").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        
        ScatteringOn();

        if (p_Data.Level < 5)
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

    void ScatteringOn()
    {
       

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (p_Data.Level >= 5 && p_Character.p_MP > 20) {
                isUse = true;
                OriGunEnd.SetActive(false);
                isScatteringOn = true;
                for (int i = 0; i < GunEnd.Length; i++)
                {
                    GunEnd[i].SetActive(true);
                }
                if (Skill1Act)
                {
                    p_Character.p_MP -= 20;
                    Skill1Act = false;
                }
            }
        }

        if (isUse)
        {
            Timer += Time.deltaTime;
            Fill.fillAmount = 1 - (Timer / ColdTime);

            if (Timer > SkillTime)
            {
                OriGunEnd.SetActive(true);
                isScatteringOn = false;
                for (int i = 0; i < GunEnd.Length; i++)
                {
                    GunEnd[i].SetActive(false);
                }
            }

            if (Timer >= ColdTime)
            {
                Fill.fillAmount = 0;
                Timer = 0;
                isUse = false;
                Skill1Act = true;
            }

        }
    }
}
