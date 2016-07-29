using UnityEngine;
using System.Collections;

public class SpwanController : MonoBehaviour {

    public GameObject EnemyPrefabs;

    public float SpwanTime = 15;
    public float SpwanTimelessen = 5;
    private float Timer;

	// Use this for initialization
	void Start () {
        
        InvokeRepeating("SpwanFast", 0, SpwanTimelessen);
	}

    void SpwanFast()
    {
        if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING)
        {
            SpwanTime -= 0.1f;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager._intance.GameState == GameManager.GAMESTATE_START)
        {
            Timer = SpwanTime;
        }

        if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING) {
            
            Timer += Time.deltaTime;
            if (Timer > SpwanTime)
            {
                Timer -= SpwanTime;
                SpwanEnemy();
            }
        }

    }

    void SpwanEnemy()
    {
        GameObject.Instantiate(EnemyPrefabs, transform.position, transform.rotation);
    }
}
