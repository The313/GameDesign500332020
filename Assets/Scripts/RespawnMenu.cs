using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    [SerializeField] private string LevelName;
    public GameObject player;
    public GameObject respawnMenuUI;
    public void RespawnatTown(){
        PlayerData.GetInstance().RespawnTown();
        respawnMenuUI.SetActive(false);
        SceneManager.LoadScene(LevelName);
    }
    public void RespawnHere(){
        PlayerData.GetInstance().RespawnHere();
        Scene scene = SceneManager.GetActiveScene();
        respawnMenuUI.SetActive(false);
        player.SetActive(true);
        SceneManager.LoadScene(scene.name);
    }
}
