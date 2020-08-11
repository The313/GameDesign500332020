using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public Transform[] spawnpos;
    public GameObject Boss;
    private void Start(){
        int i = Random.Range(0, spawnpos.Length);
        Instantiate(Boss, spawnpos[i].position, spawnpos[i].rotation);

    }
}
