using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5;
    
    private Transform p_pos;
    private Rigidbody p_Rigibody;
    private Animator p_Anima;

    private int Ground;
    

	// Use this for initialization
	void Start () {
        p_pos = GetComponent<Transform>();
        p_Rigibody = GetComponent<Rigidbody>();
        p_Anima = GetComponent<Animator>();
        Ground = LayerMask.GetMask("Ground");

	}
	
	// Update is called once per frame
	void Update () {

        //角色移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        p_Rigibody.MovePosition(p_pos.position + move*moveSpeed*Time.deltaTime);

        //角色旋转
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayinfo;
        if(Physics.Raycast(ray, out rayinfo, 100, Ground))
        {
            Vector3 tar = rayinfo.point;
            tar.y = transform.position.y;
            transform.LookAt(tar);
        }
        

        //动画播放
        if (h != 0 || v != 0)
        {
            p_Anima.SetBool("isMove",true);
        }
        else {
            p_Anima.SetBool("isMove",false);
        }

        
	}
    
    
}
