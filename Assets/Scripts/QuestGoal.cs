using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal
{
    public string Description{ get; set;}
    public string Enemytag{get; set;}
    public bool Completed{ get; set;}
    public int currentAmt{ get; set;}
    public int RequiredAmt{ get; set;}

    public void Evaluate(){
        if (currentAmt >= RequiredAmt){
            Complete();
        }
    }
    public void Complete(){
        Completed = true;
    }
    public QuestGoal(string EnemyTag, string description, bool completed, int currentamount, int requiredamount){
        this.Enemytag = EnemyTag;
        this.Description = description;
        this.Completed = completed;
        this.currentAmt = currentamount;
        this.RequiredAmt = requiredamount;
    }
    void EnemyDied(Enemy enemy){
        if (enemy.tag == "Slime"){
            this.currentAmt++;
            Evaluate();
        }
    }
}
