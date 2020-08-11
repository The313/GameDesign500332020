using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManage : MonoBehaviour
{
    public Text nameText;
    public Text dialoguetext; 
    private Queue<string> sentences;

    public Animator animator;
    private void Awake()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence){
        dialoguetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialoguetext.text += letter;
            yield return null;
        }
    }
    public void EndDialogue(){
        animator.SetBool("IsOpen", false);
    }

}
