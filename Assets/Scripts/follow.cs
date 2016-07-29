using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {

    private GameObject player;

    private float smoothing = 5f;
    private bool c_Rota = true;
	
	// Update is called once per frame
	void Update () {
        if (GameManager._intance.GameState == GameManager.GAMESTATE_START)
        {
            Vector3 oriPos = new Vector3(0,5,0);
            Quaternion oriRota = Quaternion.Euler(0, 0, 0);
            transform.position = oriPos;
            transform.rotation = oriRota;
        }

        if (c_Rota && GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //摄像头移动
        if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING)
        {
            Vector3 tar = player.transform.position + new Vector3(0, 9, -10);
            transform.position = Vector3.Lerp(transform.position, tar, smoothing * Time.deltaTime);
        }
        //摄像头旋转
        
        

        if (c_Rota && GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING)
        {
            Quaternion rotation = Quaternion.Euler(30, 0, 0);
            transform.rotation = rotation;
            c_Rota = false;
        }

        if(GameManager._intance.GameState == GameManager.GAMESTATE_END)
        {
            c_Rota = true;
        }
        
	}
}
