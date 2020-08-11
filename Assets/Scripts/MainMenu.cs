using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerData playerData;
    public void NewGame(){
        Destroy(playerData);
        SceneManager.LoadScene("Area1 Forest Start Tutorial Area");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
