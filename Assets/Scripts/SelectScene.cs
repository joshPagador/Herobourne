using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour {

    public GameObject soundPlay;

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        DontDestroyOnLoad(soundPlay); //does not destroy object automatically when loading new secene
    }

		
	
}
