using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifacteButton : MonoBehaviour{

    int index;
    public HeroInformation heroInformation;
    public AudioManager audioManager;

    public void SellButton() {
        index = transform.GetSiblingIndex();
        Transform parent = transform.parent.parent.parent;
        int price = ItemDataManager.itemDataBase.artifactes[HeroInformation.player.inventoryArtifacte[index]].price;
        HeroInformation.player.inventoryArtifacte.RemoveAt(index);
        HeroInformation.player.gold += price;
        HeroInformation.UpdateInformation();
        audioManager.MenuAudio(1);
        parent.SendMessage("SetArtifactes");
    }

    public void GetButton() {
        index = transform.GetSiblingIndex();
        Transform parent = transform.parent.parent.parent;
        HeroInformation.player.currentArtifactes.Add(HeroInformation.player.inventoryArtifacte[index]);
        HeroInformation.player.UpdateAbilitys();
        HeroInformation.player.inventoryArtifacte.RemoveAt(index);
        HeroInformation.player.cellArtifactes--;
        audioManager.MenuAudio(0);
        parent.SendMessage("SetArtifactes");
        HeroInformation.ButtonSet(true);
    }
}
