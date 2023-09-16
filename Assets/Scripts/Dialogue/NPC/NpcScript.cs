using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : NpcScriptHelper{

    private void OnTriggerEnter(Collider other) {
        DialogueEventManager.DialogueEnable();
        DialogueNodes(0);
    }

    public void DialogueNodes(int node) {

        switch (node) {
            case 0:
            begin();
            end();
            if (PlayerPrefs.GetInt("QUEST_COUNT") == 0) goto case 10;
            else if (PlayerPrefs.GetInt("QUEST_COUNT") == 6) {
                goto case 3;
            }
            else {
                int q = PlayerPrefs.GetInt("QUEST_COUNT");
                string quest = "QUEST_" + q.ToString();
                int id = PlayerPrefs.GetInt(quest);
                if (q == 1) {
                    if (id == 2) goto case 130;
                    else goto case 500;
                } else if (q == 4) {
                    if (id == 2) goto case 180;
                    else goto case 500;
                } else if (q == 5) {
                    if (id == 2) goto case 200;
                    else goto case 500;
                } else {
                    if (id == 2) goto case 4;
                    else goto case 500;
                }
            }

            case 3:
            npc(3);
            player(2, 1000);
            end();
            break;

            case 4:
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.EXP, 1000 * PlayerPrefs.GetInt("QUEST_COUNT")));
            switch (PlayerPrefs.GetInt("QUEST_COUNT")) {
                case 2:
                npc(600);
                break;
                case 3:
                npc(601);
                break;
                case 4:
                npc(602);
                break;
            }
            player(5, 300);
            end();
            break;

            case 10:
            PlayerPrefs.SetInt("QUEST_COUNT", 1);
            npc(10);
            player(11, 20);
            player(12, 112);
            end();
            break;

            case 20:
            npc(20);
            player(21, 30);
            player(22, 111);
            end();
            break;

            case 30:
            npc(30);
            player(31, 40);
            player(32, 110);
            end();
            break;

            case 40:
            npc(40);
            player(41, 50);
            player(42, 111);
            end();
            break;

            case 50:
            npc(50);
            player(51, 60);
            end();
            break;

            case 60:
            npc(60);
            player(61, 70);
            end();
            break;

            case 70:
            npc(70);
            player(71, 80);
            end();
            break;

            case 80:
            //здесь награда меч
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.SWORD));
            npc(80);
            player(81, 1000);
            player(82, 90);
            end();
            break;

            case 90:
            //здесь награда артефакт
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.ART));
            npc(90);
            player(91, 1000);
            player(92, 100);
            end();
            break;

            case 100:
            //здесь награда опыт
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.EXP, 500));
            npc(100);
            player(1, 1000);
            end();
            break;

            case 110:
            npc(110);
            player(1, 1000);
            end();
            break;

            case 111:
            npc(111);
            player(1, 1000);
            end();
            break;

            case 112:
            npc(112);
            player(1, 1000);
            end();
            break;

            case 130:
            // здесь награда опыт
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.EXP, 5000));
            npc(130);
            player(131, 140);
            player(132, 170);
            end();
            break;

            case 140:
            npc(140);
            player(141,145);
            end();
            break;

            case 145:
            npc(145);
            player(146, 150);
            end();
            break;

            case 150:
            npc(150);
            player(151, 160);
            end();
            break;

            case 160:
            npc(160);
            player(5, 175);
            end();
            break;

            case 170:
            npc(170);
            player(5, 175);
            end();
            break;

            case 175:
            PlayerPrefs.SetInt("QUEST_COUNT", 2);
            npc(175);
            player(Random.Range(308, 312), 600);
            player(Random.Range(312, 316), 601);
            player(Random.Range(316, 320), 602);
            end();
            break;

            case 180:
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.EXP, 15000));
            npc(180);
            player(5, 190);
            end();
            break;

            case 190:
            //здесь награда опыт и меч
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.SWORD));
            PlayerPrefs.SetInt("QUEST_COUNT", 5);
            npc(190);
            player(2, 1000);
            end();
            break;

            case 200:
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.EXP, 25000));
            npc(200);
            player(201, 210);
            end();
            break;

            case 210:
            PlayerPrefs.SetInt("QUEST_COUNT", 6);
            npc(210);
            player(2, 1000);
            end();
            break;

            case 300:
            int qcc = PlayerPrefs.GetInt("QUEST_COUNT");
            qcc++;
            PlayerPrefs.SetInt("QUEST_COUNT", qcc);
            npc(Random.Range(300, 308));
            player(Random.Range(308, 312), 600);
            player(Random.Range(312, 316), 601);
            player(Random.Range(316, 320), 602);
            end();
            break;

            case 400:
            if (PlayerPrefs.GetInt("QUEST_COUNT") == 5) npc(406);
            else
            npc(Random.Range(400, 404));
            player(2, 1000);
            end();
            break;

            case 500:
            //npc(Random.Range(500, 515));
            switch (PlayerPrefs.GetInt("QUEST_COUNT")) {
                case 1:
                npc(700);
                break;
                case 2:
                npc(701);
                break;
                case 3:
                npc(702);
                break;
                case 4:
                npc(703);
                break;
                case 5:
                npc(704);
                break;
                default:
                break;
            }
            player(1, 1000);
            end();
            break;

            case 600:
            // награда меч
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.SWORD));
            goto case 400;

            case 601:
            //награда артефакт
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.ART));
            goto case 400;

            case 602:
            //награда золото
            DialogueEventManager.DialogueReward(new DialogueReward(DialogueReward.Reward.GOLD, PlayerPrefs.GetInt("QUEST_COUNT") * 2000));
            goto case 400;

            case 1000:
            GamePlayManager.SetNpcIndicator();
            exit();
            break;
        }
    }
}
