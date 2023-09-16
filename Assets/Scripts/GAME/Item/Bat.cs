using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {
    Vector3 firstPosition;
	void OnEnable() {
        firstPosition = transform.position;
        StartCoroutine(TimerBat());
	}
	void Update () {
        transform.Translate( Vector3.up * Time.deltaTime * 1.8f );
    }
    IEnumerator TimerBat() {
        yield return new WaitForSeconds(3);
        transform.position = firstPosition;
        transform.gameObject.SetActive(false);
    }
}
