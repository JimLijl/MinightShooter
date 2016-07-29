using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    private Light shootLight;
    private ParticleSystem shootParticle;
    private LineRenderer shootLine;
    private AudioSource shootAudio;

    private float Timer = 0;
    private float shootFrequency = 2;
    public float Attack = 30;

    // Use this for initialization
    void Start () {
        shootLight = GetComponent<Light>();
        shootParticle = GetComponentInChildren<ParticleSystem>();
        shootLine = GetComponent<Renderer>() as LineRenderer;
        shootAudio = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0))
        {
            Shoot();
            if (Attack != 30)
            {
                Invoke("ResetAttack", 0.5f);
            }
        }
	}

    void Shoot()
    {

        
        Timer += Time.deltaTime;
        if (Timer >= 1/shootFrequency)
        {
            Timer -= 1 / shootFrequency;
            shootLight.enabled = true;
            shootParticle.Play();

            shootLine.enabled = true;
            shootLine.SetPosition(0, transform.position);
            Ray shootray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if(Physics.Raycast(shootray, out hitInfo))
            {
                shootLine.SetPosition(1,hitInfo.point);
                if (hitInfo.collider.tag == "Enemy")
                {
                    
                    hitInfo.collider.GetComponent<EnemyCharacter>().TakeHurt(Attack);
                }
            } else
            {
                shootLine.SetPosition(1, transform.position + transform.forward * 100);
            }

            shootAudio.Play();

            Invoke("ShootOver",0.05f);

            
        }
    }

    void ShootOver()
    {
        shootLight.enabled = false;
        shootLine.enabled = false;
    }

    void ResetAttack()
    {
        Attack = 30;
        shootLine.material.color = new Color(184,208,118);
    }
}
