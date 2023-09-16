using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveArtifacte : MonoBehaviour{
    public AudioManager audioManager;
    public ArtifactesInfo artifactesInfo;
    public delegate void RemoveDelegate();
    public static event RemoveDelegate removeArtifacte;
    public void Remove() {
        int index = transform.GetSiblingIndex();
        HeroInformation.player.inventoryArtifacte.Add(HeroInformation.player.currentArtifactes[index]);
        HeroInformation.player.currentArtifactes.RemoveAt(index);
        HeroInformation.player.cellArtifactes++;
        HeroInformation.player.UpdateAbilitys();
        audioManager.MenuAudio(0);
        artifactesInfo.SetArtifactes();
        removeArtifacte();
    }
}
