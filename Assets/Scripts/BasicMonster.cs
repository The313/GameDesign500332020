using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : MonoBehaviour
{
    public float basedamage = 0.0f;
    public float skilldamage = 0.0f;
    public float movespeed = 4.0f;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
