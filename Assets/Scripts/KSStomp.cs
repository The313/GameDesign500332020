using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSStomp : MonoBehaviour
{
    public int StompDamage = 20;
    public GameObject player;

	public void Stomp(){
        if (player.GetComponent<PlayerController>().GetGrounded()){
            player.GetComponent<BasicCombat>().TakeDamage(StompDamage);
        }
    }
}
