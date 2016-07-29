using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyChose : MonoBehaviour {

    public Toggle Easy;
    public Toggle Normal;
    public Toggle Hard;
    public Text e_Score;
    public Text e_HighScore;
    public Text n_Score;
    public Text n_HighScore;
    public Text h_Score;
    public Text h_HighScore;
    private Text Score;

    private PlayerData p_Data;
    private SpwanController BunnySpwan;
    private SpwanController BearSpwan;
    private SpwanController EphantSpwan;

    private float SpwanTime = 5;
    private float SpwanTimelessen = 1;
    

    // Use this for initialization
    void Start () {
        BunnySpwan = GameObject.FindGameObjectWithTag(Tags.BunnySpwan).GetComponent<SpwanController>();
        BearSpwan = GameObject.FindGameObjectWithTag(Tags.BearSpwan).GetComponent<SpwanController>();
        EphantSpwan = GameObject.FindGameObjectWithTag(Tags.EphantSpwan).GetComponent<SpwanController>();
        Score = GameObject.FindGameObjectWithTag(Tags.Score).GetComponent<Text>();
        p_Data = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager._intance.GameState == GameManager.GAMESTATE_START)
        {
            DiffChose();
        }
        if (GameManager._intance.GameState == GameManager.GAMESTATE_END)
        {
            WriteScore();
        }



    }

    void DiffChose()
    {
        if (Easy.isOn)
        {
            SpwanTime = 15;
            SpwanTimelessen = 5;
            SetDifficulty(SpwanTime, SpwanTimelessen);
        }

        if (Normal.isOn)
        {
            SpwanTime = 10;
            SpwanTimelessen = 3;
            SetDifficulty(SpwanTime, SpwanTimelessen);
        }

        if (Hard.isOn)
        {
            SpwanTime = 2;
            SpwanTimelessen = 1;
            SetDifficulty(SpwanTime, SpwanTimelessen);
        }
    }

    void SetDifficulty(float SpwanTime,float SpwanTimelessen)
    {
        BunnySpwan.SpwanTime = SpwanTime;
        BunnySpwan.SpwanTimelessen = SpwanTimelessen;
        BearSpwan.SpwanTime = SpwanTime;
        BearSpwan.SpwanTimelessen = SpwanTimelessen;
        EphantSpwan.SpwanTime = SpwanTime;
        EphantSpwan.SpwanTimelessen = SpwanTimelessen;

    }

    void WriteScore()
    {
        if (Easy.isOn)
        {
            e_Score.text = Score.text;
            if(GameManager._intance.Score > p_Data.e_HighScroe)
            {
                p_Data.e_HighScroe = GameManager._intance.Score;
            }
            e_HighScore.text = "Score:" + p_Data.e_HighScroe;
        }
        else
        {
            e_Score.text = "当前游戏难度不是简单";
            e_HighScore.text = "Score:" + p_Data.e_HighScroe;
        }

        if (Normal.isOn)
        {
            n_Score.text = Score.text;
            if (GameManager._intance.Score > p_Data.n_HighScore)
            {
                p_Data.n_HighScore = GameManager._intance.Score;
            }
            n_HighScore.text = "Score:" + p_Data.n_HighScore;
        }
        else
        {
            n_Score.text = "当前游戏难度不是一般";
            n_HighScore.text = "Score:" + p_Data.n_HighScore;
        }

        if (Hard.isOn)
        {
            h_Score.text = Score.text;
            if (GameManager._intance.Score > p_Data.h_HighScore)
            {
                p_Data.h_HighScore = GameManager._intance.Score;
            }
            h_HighScore.text = "Score:" + p_Data.h_HighScore;
        }
        else
        {
            h_Score.text = "当前游戏难度不是困难";
            h_HighScore.text = "Score:" + p_Data.h_HighScore;
        }
    }
}
