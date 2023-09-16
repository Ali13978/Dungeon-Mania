using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour {

    public GameController gameController;
    public GameObject pauseObject;

    private void Start() {
        gameController.Pause();
        StartCoroutine(StartBeginGame());
    }

    public IEnumerator StartBeginGame() {
        pauseObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameController.Pause();
        pauseObject.SetActive(true);
    }
}

