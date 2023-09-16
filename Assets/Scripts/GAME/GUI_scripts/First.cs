using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class First : MonoBehaviour{
    public AudioClip first;
    public Slider slider;
    public void FirstLoad()
    {
        StartCoroutine(Loading());
    }
    IEnumerator Loading(){
        GetComponent<AudioSource>().PlayOneShot(first);
        yield return null;
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        while(!async.isDone){
            slider.value = async.progress;
            if(slider.value >= 0.9f) async.allowSceneActivation = true;
            yield return null;
        }
    }
}
