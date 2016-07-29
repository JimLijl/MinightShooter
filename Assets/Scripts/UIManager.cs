using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject startBtn;
    public GameObject startBtnMoveto;
    public GameObject startBtnMoveback;
    public GameObject quitBtn;
    public GameObject quitBtnMoveto;
    public GameObject quitBtnMoveback;
    public GameObject settingBtn;
    public GameObject settingBtnMoveto;
    public GameObject settingBtnMoveback;
    public GameObject GameName;
    public GameObject GameNameMoveto;
    public GameObject GameNameMoveback;
    public GameObject settingObject;
    public GameObject settingObjectback;
    public GameObject PlayerState;
    public GameObject PlayerStateMoveto;
    public GameObject PlayerStateMoveback;
    public GameObject GameOver;
    public GameObject GameOverMoveback;
    public GameObject Score;
    public GameObject ScoreMoveto;
    public GameObject ScoreMoveback;
    public Slider Exp;
    public Image startBg;
    private PlayerData p_Data;
    private Text ScoreNum;
    private Text Level;

    void Start()
    {
        ScoreNum = Score.GetComponent<Text>();
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
        Level = Exp.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager._intance.GameState == GameManager.GAMESTATE_START)
        {
            startBg.CrossFadeAlpha(0.5f, 1, true);
            iTween.MoveTo(Score, ScoreMoveback.transform.position, 1f);
        }

        if (GameManager._intance.GameState == GameManager.GAMESTATE_PLAYING)
        {
            startBg.CrossFadeAlpha(0, 1, true);
            iTween.MoveTo(Score, ScoreMoveto.transform.position, 1f);
        }

        ScoreNum.text = "Score:"+GameManager._intance.Score;
        Exp.value = p_Data.AcquiredExp / p_Data.Exp;
        Level.text = "LV." + p_Data.Level;
	}

    public void PlayerStateInScene()
    {
        iTween.MoveTo(PlayerState, PlayerStateMoveto.transform.position, 1f);
    }

    public void PlayerStateOut()
    {
        iTween.MoveTo(PlayerState, PlayerStateMoveback.transform.position, 1f);
    }

    public void BtnMove()
    {
        iTween.MoveTo(startBtn, startBtnMoveto.transform.position, 1f);
        iTween.MoveTo(quitBtn, quitBtnMoveto.transform.position, 1f);
        iTween.MoveTo(settingBtn, settingBtnMoveto.transform.position, 1f);
        iTween.MoveTo(GameName, GameNameMoveto.transform.position, 1f);
    }

    public void BtnMoveBack()
    {
        iTween.MoveTo(startBtn, startBtnMoveback.transform.position, 1f);
        iTween.MoveTo(quitBtn, quitBtnMoveback.transform.position, 1f);
        iTween.MoveTo(settingBtn, settingBtnMoveback.transform.position, 1f);
        iTween.MoveTo(GameName, GameNameMoveback.transform.position, 1f);
    }

    public void SettingInScene()
    {
        iTween.MoveTo(settingObject, this.transform.position, 1.5f);
        BtnMove();
    }
    public void Settingback()
    {
        iTween.MoveTo(settingObject, settingObjectback.transform.position, 1.5f);
        BtnMoveBack();
    }

    public void OverInScene()
    {
        iTween.MoveTo(GameOver, this.transform.position, 1.5f);
    }

    public void OverMoveback()
    {
        iTween.MoveTo(GameOver,GameOverMoveback.transform.position, 1.5f);
    }
}
