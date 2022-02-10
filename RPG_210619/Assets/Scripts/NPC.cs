using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    //public string[] lines;

    public override void Interact()
    {
        base.Interact();

        //DialogueSystem.instance.AddDialogues(lines);
        GetComponent<QuestGiver>().GiveQuest();
    }
}
