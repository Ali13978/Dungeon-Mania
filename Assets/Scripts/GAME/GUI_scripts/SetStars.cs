using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class SetStars : MonoBehaviour{
    static Transform thisTransform;
    static Sprite[] stars;
    public Sprite[] starsSprite;
    void Awake(){
        thisTransform = GetComponent<Transform>();
        stars = starsSprite;
    }
    void Start(){
        Set();
    }
    public static void Set(){
        foreach (Transform tr in thisTransform) {
            tr.GetComponent<Image>().sprite = stars[0];
            if (tr.GetSiblingIndex() < HeroInformation.player.dungeonLevel) {
                if (HeroInformation.player.gameLevel < 4) tr.GetComponent<Image>().sprite = stars[HeroInformation.player.gameLevel];
                else tr.GetComponent<Image>().sprite = stars[3];
            }
        }
    }
}
