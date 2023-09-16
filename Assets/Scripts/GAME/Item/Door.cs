using UnityEngine;
public class Door : MonoBehaviour{
    Animator animator;
    public bool isArenaDoor;
    bool open;
    GameObject gameManager;
    GameController gameController;
    public GameObject indicator;
    TextMesh textMesh;
    AudioManager audioManager;
    void Awake(){
        animator = transform.GetChild(0).GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        gameController = gameManager.GetComponent<GameController>();
        audioManager = gameManager.GetComponent<AudioManager>();
        textMesh = indicator.GetComponent<TextMesh>();
        textMesh.text = "";
    }
    void OnEnable(){
        EnemyEvent.CloseDoor += Close;
    }
    void OnDisable(){
        EnemyEvent.CloseDoor -= Close;
    }
    void OnTriggerEnter(){
        if (isArenaDoor) {
            CheckDoor();
        } else {
            if (GamePlayManager.level.isSweep) {
                CheckDoor();
            } else {
                textMesh.text = "!";
            }
        }
    }
    void OnTriggerStay(){
        if (isArenaDoor) {
            if (!open & HeroInformation.player.keys > 0) {
                HeroInformation.player.keys--;
                HeroInformation.UpdateInformation();
                Open();
            }
        } else {
            if (!open & GamePlayManager.level.isSweep & HeroInformation.player.keys > 0) {
                HeroInformation.player.keys--;
                HeroInformation.UpdateInformation();
                Open();
            }
        }
    }
    void OnTriggerExit(){
        if (isArenaDoor) return;
        else {
            if (!open) textMesh.text = "";
        }
    }
    void CheckDoor() {
        /*
        if (!open) {
            if (HeroInformation.player.keys > 0) {
                HeroInformation.player.keys--;
                HeroInformation.UpdateInformation();
                Open();
            } else
                gameController.ads.AdInfo(AdsManager.Earned.key, 3);
        } else return;
        */
        if (!open) Open();
        else return;
    }
    public void Open(){
        audioManager.DoorAudioOpen();
        animator.Play("open");
        open = true;
    }
    public void Close(){
        if (open) {
            audioManager.DoorAudioClose();
            animator.Play("close");
            open = false;
        }
    }
    public void CloseOldDoor() {
        if (isArenaDoor) return;
        else {
            Close();
        }
    }
}
