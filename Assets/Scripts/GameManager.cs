using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static int GAMESTATE_START      = 0;
    public static int GAMESTATE_PLAYING    = 1;
    public static int GAMESTATE_END        = 2;

    public int GameState = GAMESTATE_START;

    public static GameManager _intance;

    private GameObject Enemy;
    private PlayerCharacter p_Character;
    private PlayerController p_Controller;
    private PlayerShoot p_Shoot;
    private PlayerData p_Data;
    private UIManager UIManager;

    public int Score = 0;
    void Awake()
    {
        _intance = this;
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
        p_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        p_Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        p_Shoot = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerShoot>();
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        Enemy = GameObject.FindGameObjectWithTag(Tags.enemy);
    }

    void Update()
    {
        if (GameState == GAMESTATE_START)
        {
            p_Data.ReadData();
            
        }

        if (GameState != GAMESTATE_PLAYING)
        {
            p_Character.enabled = false;
            p_Controller.enabled = false;
            p_Shoot.enabled = false;
        }

        if (GameState == GAMESTATE_END)
        {
            p_Data.SaveData();
            EndGame();
            if (Enemy)
            {
                Destroy(Enemy);
            }
        }


    }

    public void ResetPlayer()
    {
        p_Data.ResetData();
    }

    public void StartGame()
    {
        if (GameState== GAMESTATE_START) {
            
            Score = 0;
            GameState = GAMESTATE_PLAYING;
            UIManager.BtnMove();
            UIManager.PlayerStateInScene();
            p_Character.enabled = true;
            p_Controller.enabled = true;
            p_Shoot.enabled = true;

        }
    }

    void EndGame()
    {
        p_Character.enabled = false;
        p_Controller.enabled = false;
        p_Shoot.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag(Tags.enemy));
        UIManager.OverInScene();
        
        
    }

    public void Restart()
    {
        GameState = GAMESTATE_START;
        UIManager.OverMoveback();
        UIManager.BtnMoveBack();
        UIManager.PlayerStateOut();
        p_Character.ResetPlayer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
