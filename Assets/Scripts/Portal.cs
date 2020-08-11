using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string LevelName;
    public Animator transition;
    public bool portalEntered = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.W) && portalEntered){
                Debug.Log("To Next Scene");
                portalEntered = false;
                StartCoroutine(LoadLevel(LevelName));
            }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            portalEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            portalEntered = false;
        }
    }
    IEnumerator LoadLevel(string LevelName){
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelName);
    }
}
