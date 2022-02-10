using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : BaseStats
{
    public int enemyID = 0;

    public override void Die()
    {
        base.Die();

        PlayerManager.instance.player.GetComponent<BaseStats>().exp.GainXP(10);
        PlayerManager.instance.player.GetComponent<QuestList>().OnUpdateRequirement(enemyID);
        PlayerManager.instance.player.GetComponent<CharacterCombat>().StopAttacking();

        if (GetComponent<Enemy>().spawner != null) GetComponent<Enemy>().spawner.Respawn();
        Destroy(this.gameObject);
    }
}
