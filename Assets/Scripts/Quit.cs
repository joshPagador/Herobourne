using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public void quit()
    {
        Application.Quit(); //quits the executable
        Debug.Log("Quitted game"); 
    }
}
