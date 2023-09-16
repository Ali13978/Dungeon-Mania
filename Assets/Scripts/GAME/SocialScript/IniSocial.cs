using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;
public class IniSocial : MonoBehaviour{
    void Start(){
#if UNITY_ANDROID
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {});
#elif UNITY_IPHONE
        Social.localUser.Authenticate(
            success =>{
                if(success) Debug.Log("ok");
                else Debug.Log("not ok");
            }
        );
#endif
    }
}
