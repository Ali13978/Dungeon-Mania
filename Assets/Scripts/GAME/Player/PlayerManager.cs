using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour{
    public Slider sliderHelth;
    public Slider sliderExperiance;
    public GameObject cameraSystem;
    public SetEnemyRoom firstLevel;
    [HideInInspector]public Animator animator ;
    public static Rigidbody rb ;
    [HideInInspector]public MainInput mainInput ;
    [HideInInspector]public Attack attackScript ;
    [HideInInspector]public PlayerHelth playerHelth;
    [HideInInspector]public PlayerBar playerBar;
    [HideInInspector]public PlayerFXmanager fXmanager;
    GameObject gameManager;
    [HideInInspector]public AudioManager audioManager;
    void Awake(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mainInput = GetComponent<MainInput>();
        attackScript = GetComponent<Attack>();
        playerHelth = GetComponent<PlayerHelth>();
        playerBar = GetComponent<PlayerBar>();
        fXmanager = GetComponent<PlayerFXmanager>();
        gameManager = GameObject.Find("GameManager");
        audioManager = gameManager.GetComponent<AudioManager>();
    }
    public void PlayerWin(int i){
        fXmanager.common[i].transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        fXmanager.common[i].Play();
    }
}



