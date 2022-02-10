using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    #region Singleton
    public static DialogueSystem instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject dialoguePanel;
    public Text dialogueText;

    public List<string> dialogues = new List<string>();

    int dialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddDialogues(string[] lines)
    {
        if (dialoguePanel.activeSelf == true) return;

        //dialogues = new List<string>();

        foreach(var line in lines)
        {
            dialogues.Add(line);
        }

        dialogueText.text = dialogues[dialogueIndex];
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex >= dialogues.Count)
        {
            dialoguePanel.SetActive(false);
            dialogueIndex = 0;
            dialogues = new List<string>();
            return;
        }

        dialogueText.text = dialogues[dialogueIndex];
    }
}
