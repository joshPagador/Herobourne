using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource myMusic;
	private float volume;


	// Update is called once per frame
	void Update ()

    {
        // take slider value to make volume the same
        myMusic.volume = Volume.value;   
		
	}


    //mute script

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;

    }

}
