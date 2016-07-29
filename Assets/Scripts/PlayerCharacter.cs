using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {

    private PlayerController p_Controller;
    private Animator p_anim;
    private SkinnedMeshRenderer p_SkinnedMeshRenderer;
    private PlayerShoot p_Shoot;
    private PlayerSkill p_Skill;
    private Slider HP_Slider;
    private Slider MP_Slider;

    public float p_HP = 100;
    public float p_MP = 100;
    private float smoothing = 3;

    // Use this for initialization
    void Start()
    {
        p_Controller = GetComponent<PlayerController>();
        p_Shoot = GetComponentInChildren<PlayerShoot>();
        p_anim = GetComponent<Animator>();
        p_Skill = GetComponent<PlayerSkill>();
        p_SkinnedMeshRenderer = transform.Find("Player").GetComponent<Renderer>() as SkinnedMeshRenderer;
        HP_Slider = GameObject.FindGameObjectWithTag(Tags.HPSlider).GetComponent<Slider>();
        MP_Slider = GameObject.FindGameObjectWithTag(Tags.MPSlider).GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
       
        if(p_HP <= 0)
        {
            GameManager._intance.GameState = GameManager.GAMESTATE_END;
        }

        if(p_MP < 100)
        {
            p_MP += 0.05f;
        }

        if (p_HP == 100)
        {
            p_Controller.enabled = true;
            p_Shoot.enabled = true;
            p_Skill.enabled = true;
        }
        
        p_SkinnedMeshRenderer.material.color = Color.Lerp(p_SkinnedMeshRenderer.material.color, Color.white, smoothing * Time.deltaTime);

        HP_Slider.value = p_HP;
        MP_Slider.value = p_MP;
    }

    public void takeHurt(float damage)
    {

        if (p_HP <= 0) return;
        p_HP = p_HP - damage;
        if(damage == 0)
        {
            p_SkinnedMeshRenderer.material.color = Color.green;
        }
        else
        {
            p_SkinnedMeshRenderer.material.color = Color.red;
        }
        
        if (this.p_HP <= 0)
        {
            p_anim.SetBool("isDeath",true);
            p_Controller.enabled = false;
            p_Shoot.enabled = false;
            p_Skill.enabled = false;
        }

    }

    public void ResetPlayer()
    {
        p_HP = 100;
        p_MP = 100;
        this.transform.position = new Vector3(0,0,0);
        Quaternion rotation = Quaternion.Euler(0,0,0);
        transform.rotation = rotation;
        p_anim.SetBool("isDeath",false);
    }
}
