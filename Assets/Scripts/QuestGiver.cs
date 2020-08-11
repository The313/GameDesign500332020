using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest sidequest1;
    public GameObject player;
    public GameObject questwindow;
    public Text titleText;
    public Text descText;
    public Text expText;
    public Text goldText;

    public void OpenQuestWindow(){
        questwindow.SetActive(true);
        titleText.text= sidequest1.title;
        descText.text = sidequest1.description;
        expText.text = sidequest1.expReward.ToString();
        goldText.text = sidequest1.goldReward.ToString();
    }
    public void AcceptQuest(){
        questwindow.SetActive(false);
        sidequest1.isActive = true;
    }
}
