using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int Health;

    int ContactDmg;
    int Gold;
    int EXP;
    float followradius;
    int speed;

    public Animator animator;
    // Start is called before the first frame update

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }

    public void setContactDamage(int attdmg)
    {
        ContactDmg = attdmg;
    }

    public void setHP(int lp)
    {
        Health = lp;
    }

    public int getSpeed()
    {
        return speed;
    }

    public int getContactDamage()
    {
        return ContactDmg;
    }

    public int getHP()
    {
        return Health;
    }


    //movement toward a player
    public void setFollowRadius(float r)
    {
        followradius = r;
    }
    //if player in radius move toward him 
    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if(Mathf.Abs(playerPosition -enemyPosition) < followradius)
        {
            //player in range
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeDamage(int damage){
        Health -= damage;
        //play hurt animation
        animator.SetTrigger("mobhurt");
        if (Health < 0){
            Die();
        }
    }

    

    void Die(){
        //death animation
        animator.SetTrigger("mobDeath");
        //Enemy Disabled
        //Grant exp and gold

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
