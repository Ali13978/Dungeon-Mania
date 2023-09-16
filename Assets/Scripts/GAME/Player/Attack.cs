using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Attack : MonoBehaviour {
    PlayerManager playerManager;
	float distanceAttack = 1.5f;
    int layerMask = 1 << 12;
    private void Awake(){
        playerManager = GetComponent<PlayerManager>();
    }
    public void Begin(){
        playerManager.audioManager.PlayerCommonAudio(4);
        playerManager.fXmanager.common[4].Play();
    }
    public void Steps(){
        playerManager.audioManager.PlayerSteps();
    }
    public void Damage(int skill) {
        Collider[] hit;
        bool isSkill;
        int damage;
        int damageElemental;
        int elementalType = 0;
        if ((int)HeroInformation.player.sword.swordMageType == 0){
            playerManager.fXmanager.slashes[0].Play();
            playerManager.audioManager.PlayerSlash(0);
            damageElemental = 0;
        }
        else{
            int percentElemental = Random.Range(1, 101);
            if (percentElemental < HeroInformation.player.sword.mageDamage + HeroInformation.player.lucky.value) {
                int mage = Random.Range(0, 4);
                if (HeroInformation.player.characterList[mage].value == 0) {
                    playerManager.fXmanager.slashes[0].Play();
                    playerManager.audioManager.PlayerSlash(0);
                    damageElemental = 0;
                } else {
                    playerManager.fXmanager.slashes[mage + 1].Play();
                    playerManager.audioManager.PlayerSlash(mage + 1);
                    damageElemental = HeroInformation.player.characterList[mage].value + 5;
                    elementalType = mage;
                }
            } else {
                playerManager.fXmanager.slashes[0].Play();
                playerManager.audioManager.PlayerSlash(0);
                damageElemental = 0;
            }
        }
        if(skill > 0){
            playerManager.audioManager.PlayerSkill(0);
            isSkill = true;
        } else isSkill = false;
        switch(skill){
            case 0:
                hit = Physics.OverlapSphere( transform.position + transform.TransformDirection( Vector3.forward ) * distanceAttack, distanceAttack, layerMask );
            break;
            case 1:
                hit = Physics.OverlapSphere( transform.position, distanceAttack, layerMask );
            break;
            case 2:
                hit = Physics.OverlapCapsule( transform.position, transform.position + (Vector3.forward * distanceAttack), 1f, layerMask );
            break;
            default:
                hit = Physics.OverlapSphere( transform.position + transform.TransformDirection( Vector3.forward ) * distanceAttack, distanceAttack, layerMask );
            break;
        }
        for (int i = 0; i < hit.Length; i++) {
            int isCrit = 0;

            damage = Random.Range(HeroInformation.player.sword.damageMin, HeroInformation.player.sword.damageMax + 1) + 3;
            damage += HeroInformation.player.attack.value;

            int checkAccuracy = Random.Range(1, 101);
            if (checkAccuracy > HeroInformation.player.accurcy.value){
                damage -= (damage * 50) / 100;
                damageElemental -= (damageElemental * 50) / 100;
                if(damage < 0) damage = 1;
                if (damageElemental < 0) damageElemental = 0;
            }
            else{
                int checkCrit = Random.Range(1, 101);
                if(skill > 0) checkCrit += 25;
                if (checkCrit <= HeroInformation.player.lucky.value) isCrit = HeroInformation.player.attack.value + HeroInformation.player.sword.damageMax;
                else isCrit = 0;
            }
            Damage damageStruct = new Damage();     
            damageStruct.damage = damage;
            damageStruct.damageElemental = damageElemental;
            damageStruct.crit = isCrit;
            damageStruct.isSpell = isSkill;
            damageStruct.elementalType = elementalType;
            hit[i].SendMessage( "Damage", damageStruct );
        }
    }
    public void Skill(int number){
        float upY = 0;
        switch(number){
            case 0:
            upY = 1f;
            break;
            case 1:
            GroundDamage();
            upY = 0.1f;
            break;
            case 2:
            Bird();
            upY = 0.5f;
            playerManager.fXmanager.skills[number].transform.rotation = transform.rotation;
            break;
            case 3:
            upY = 0;
            HeroInformation.isShield = true;
            break;
            case 4:
            upY = 3f;
            playerManager.playerHelth.currentHelth += (int)(HeroInformation.player.helth.value * (0.04f + HeroInformation.player.electricity.value * 0.02f));
            if (playerManager.playerHelth.currentHelth > HeroInformation.player.helth.value) playerManager.playerHelth.currentHelth = HeroInformation.player.helth.value;
            StartCoroutine(playerManager.playerBar.UpdateValue((float)playerManager.playerHelth.currentHelth/(float)HeroInformation.player.helth.value, playerManager.sliderHelth));
            break;
        }
        playerManager.fXmanager.skills[number].transform.position = new Vector3(transform.position.x, transform.position.y + upY, transform.position.z);
        playerManager.fXmanager.skills[number].Play();
        playerManager.audioManager.PlayerSkill(number);
    }
    public void GroundDamage (){
		Collider[] hit = Physics.OverlapSphere (transform.position, 3f, layerMask );
        Damage damageStruct = new Damage();
        damageStruct.damage = HeroInformation.player.attack.value;
        damageStruct.damageElemental = HeroInformation.player.ice.value * 2;
        damageStruct.crit = HeroInformation.player.attack.value + HeroInformation.player.ice.value;
        damageStruct.isSpell = true;
        damageStruct.spellID = 1;
		for (int i = 0; i < hit.Length; i++)  hit[i].SendMessage("Damage", damageStruct);
	}
    public void Bird(){
        RaycastHit[] hitBird = Physics.SphereCastAll(transform.position + Vector3.forward * 1f, 2f, transform.forward, 10f, layerMask );
        Damage damageStruct = new Damage();
        damageStruct.damage = HeroInformation.player.attack.value;
        damageStruct.damageElemental = HeroInformation.player.fire.value * 2;
        damageStruct.crit = HeroInformation.player.attack.value + HeroInformation.player.fire.value;
        damageStruct.isSpell = true;        
        damageStruct.spellID = 2;
        for (int i = 0; i < hitBird.Length; i++) hitBird[i].transform.SendMessage("Damage", damageStruct);
    }     
    IEnumerator Shield(){
        HeroInformation.isShield = true;
        yield return new WaitForSeconds(10f);
        HeroInformation.isShield = false;
    }
}
