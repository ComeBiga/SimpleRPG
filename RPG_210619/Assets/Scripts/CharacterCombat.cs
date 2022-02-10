using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseStats))]
public class CharacterCombat : MonoBehaviour
{
    private bool attacking = false;
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    BaseStats myStats;
    BaseStats targetStats;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<BaseStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCooldown > 0)
            attackCooldown -= Time.deltaTime;

        if (Input.GetKeyDown("d"))
        {
            myStats.TakeDamage(10);
            Debug.Log("Taken damage");
        }

        if(attacking)
        {
            Attack(targetStats);
        }
    }

    public void Attack(BaseStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack.Invoke();

            attackCooldown = 1f / attackSpeed;
        }
    }

    public void AttackCotinuously(BaseStats targetStats)
    {
        attacking = true;
        this.targetStats = targetStats;
    }

    public void StopAttacking()
    {
        attacking = false;
        targetStats = null;
    }

    IEnumerator DoDamage(BaseStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetModifiedValue());
    }
}
