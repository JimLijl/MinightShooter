using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    private Camera Camera;
    private AudioSource c_Audio;
    private Slider Slider;


	// Use this for initialization
	void Start () {
        Camera = Camera.main;
        c_Audio = Camera.GetComponent<AudioSource>();
        Slider = this.GetComponent<Slider>();
	}
	
	public void MusicCon()
    {
        c_Audio.volume = Slider.value;
    }
}
