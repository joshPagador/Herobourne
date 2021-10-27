using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    //refrence to loading screen, slider and progress text
    public GameObject loading;
    public Slider slider;
    public Text progresstext;

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }
    //asynchrously means running as a corotuine 
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loading.SetActive(true);

        //the while loop will continue running as long as operation.isdone is equal to false
        while (!operation.isDone)
        {
            // float value going from 0 to 1
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progresstext.text = progress * 100f + "%";

            yield return null;
            //waiting until next frame before continuing 
        }
    }
    
}
