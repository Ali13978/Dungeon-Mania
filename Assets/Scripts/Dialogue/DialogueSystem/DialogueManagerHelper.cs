using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerHelper : MonoBehaviour{

    public GameObject pauseObject;
    public GameController gameController;
    Transform dialogueWindows;
    public PlayerBar playerBar;
    public HeroInformation heroInformation;
    DialogueReward dialogueReward;
    bool isReward = false;
    ItemDataBase itemDataBase;
    List<DialogueReward> rewardList = new List<DialogueReward>();
    GameObject rewardInfo;
    Text rewardString;

    //public GameObject npcIndicator;

    private void OnEnable() {
        DialogueEventManager.dialogueEnable += StartDialogue;
        DialogueEventManager.dialogueDisable += ExitDialogue;
        DialogueEventManager.dialogueReward += GetReward;
    }

    private void OnDisable() {
        DialogueEventManager.dialogueEnable -= StartDialogue;
        DialogueEventManager.dialogueDisable -= ExitDialogue;
        DialogueEventManager.dialogueReward -= GetReward;
    }

    private void Start() {
        dialogueWindows = transform.GetChild(0);
        dialogueWindows.gameObject.SetActive(false);
        itemDataBase = ItemDataManager.itemDataBase;
        rewardInfo = transform.GetChild(1).gameObject;
        rewardString = rewardInfo.transform.GetChild(0).GetComponent<Text>();
        rewardInfo.SetActive(false);
    }

    void StartDialogue() {
        dialogueWindows.gameObject.SetActive(true);
        pauseObject.SetActive(false);
        gameController.Pause();
    }

    void ExitDialogue() {
        dialogueWindows.gameObject.SetActive(false);
        pauseObject.SetActive(true);
        gameController.Pause();
        if (rewardList.Count > 0) StartCoroutine(RewardInfo());
    }

    void GetReward(DialogueReward reward) {
        dialogueReward = reward;
        isReward = true;
        SwitchReward();
    }

    void SwitchReward() {
        if (isReward) {
            rewardList.Add(dialogueReward);
            switch (dialogueReward.reward) {
                case DialogueReward.Reward.EXP:
                playerBar.CheckExperience(dialogueReward.valueReward);
                break;
                case DialogueReward.Reward.GOLD:
                StartCoroutine(heroInformation.UpdateStat(dialogueReward.valueReward, 0));
                break;
                case DialogueReward.Reward.ART:
                HeroInformation.player.inventoryArtifacte.Add(itemDataBase.artifactes[Random.Range(0, itemDataBase.artifactes.Count)].index);
                break;
                case DialogueReward.Reward.SWORD:
                HeroInformation.player.inventorySword.Add(itemDataBase.swords[HeroInformation.player.indicatorSwordList].index);
                HeroInformation.player.indicatorSwordList++;
                break;
            }
            isReward = false;
        }
    }

    IEnumerator RewardInfo() {
        rewardInfo.SetActive(true);
        if (LocalizationManager.localizationIndex == 0) rewardInfo.GetComponent<Text>().text = "Получено: ";
        else rewardInfo.GetComponent<Text>().text = "Received: ";
        foreach (DialogueReward r in rewardList) {
            switch (r.reward) {
                case DialogueReward.Reward.EXP:
                string s;
                if (LocalizationManager.localizationIndex == 0) s = " опыт";
                else s = " exp";
                rewardString.text = r.valueReward.ToString() + s;
                break;
                case DialogueReward.Reward.GOLD:
                string s1;
                if (LocalizationManager.localizationIndex == 0) s1 = " золото";
                else s1 = "gold";
                rewardString.text = r.valueReward.ToString() + s1;
                break;
                case DialogueReward.Reward.SWORD:
                rewardString.text = itemDataBase.swords[HeroInformation.player.inventorySword.Count - 1].itemLocalizations[LocalizationManager.localizationIndex].name;
                break;
                case DialogueReward.Reward.ART:
                rewardString.text = itemDataBase.artifactes[HeroInformation.player.inventoryArtifacte[HeroInformation.player.inventoryArtifacte.Count - 1]].itemLocalizations[LocalizationManager.localizationIndex].name;
                break;
            }
            yield return new WaitForSeconds(1f);
        }
        rewardInfo.SetActive(false);
        rewardList.Clear();
    }
}
