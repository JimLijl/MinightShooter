using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public string Name = "Minight";
    public int Level = 1;
    public float AcquiredExp = 0;
    public float Exp = 0;
    public int e_HighScroe = 0;
    public int n_HighScore = 0;
    public int h_HighScore = 0;

    void Update()
    {
        ExpNum();
        
    }

    public void addExp(int getExp)
    {
        
        AcquiredExp += getExp;
        
    }

    void ExpNum()
    {
        Exp = Level * 100;
        if (AcquiredExp / Exp >= 1)
        {
            Level++;
            AcquiredExp = AcquiredExp - Exp;
        }
    }

    public void ResetData()
    {
        PlayerPrefs.SetString("Name", "Minight");
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetFloat("AcquiredExp", 0);
        PlayerPrefs.SetFloat("Exp", 100);
        PlayerPrefs.SetInt("e_HighScroe", 0);
        PlayerPrefs.SetInt("n_HighScore", 0);
        PlayerPrefs.SetInt("h_HighScore", 0);
    }

	public void SaveData()
    {
        PlayerPrefs.SetString("Name", "Minight");
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetFloat("AcquiredExp", AcquiredExp);
        PlayerPrefs.SetFloat("Exp", Exp);
        PlayerPrefs.SetInt("e_HighScroe", e_HighScroe);
        PlayerPrefs.SetInt("n_HighScore", n_HighScore);
        PlayerPrefs.SetInt("h_HighScore", h_HighScore);
    }

    public void ReadData()
    {
        Name = PlayerPrefs.GetString("Name");
        Level = PlayerPrefs.GetInt("Level");
        AcquiredExp = PlayerPrefs.GetFloat("AcquiredExp");
        Exp = PlayerPrefs.GetFloat("Exp");
        e_HighScroe = PlayerPrefs.GetInt("e_HighScroe");
        n_HighScore = PlayerPrefs.GetInt("n_HighScore");
        h_HighScore = PlayerPrefs.GetInt("h_HighScore");
    }
}
