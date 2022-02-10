using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    BaseStats myStats;

    public Spawner spawner;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<BaseStats>();
    }

    public override void Interact()
    {
        base.Interact();

        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            //playerCombat.Attack(myStats);
            playerCombat.AttackCotinuously(myStats);
        }

        
    }
}
