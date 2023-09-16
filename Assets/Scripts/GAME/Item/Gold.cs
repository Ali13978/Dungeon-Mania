using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    //public ParticleSystem goldParticle;
    public Transform goldLable;
    public int goldInformation;

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            goldInformation = Random.RandomRange( 50, 60 );
            int percent = ( goldInformation * (int) ( HeroInformation.player.miner.value / 100 ) );
            goldInformation += percent;
            HeroInformation.player.gold += goldInformation;
            HeroInformation.UpdateInformation();
            Transform damageLabelExp = Instantiate(goldLable, Camera.main.WorldToViewportPoint(transform.position + Vector3.up), Quaternion.identity);
            damageLabelExp.SendMessage("TimeUp", 0.2f);
            //damageLabelExp.GetComponent<GUIText>().text = "+"+goldInformation.ToString();
            //damageLabelExp.GetComponent<GUIText>().color = Color.yellow;
            //Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Awake () {
        //goldParticle.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoldInformation(int goldInformation1){
        goldInformation = goldInformation1;
    }
}
