using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public int level = 1;
    public Experience exp;

    public Stat maxHealth;
    public int currentHealth;

    public Stat damage;
    public Stat armor;

    public System.Action<int, int> onHealthChangedCallback;

    private void Awake()
    {
        exp = new Experience();
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth.value;

        exp.OnChangedLevel += OnChangedLevel;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetModifiedValue();
        currentHealth -= Mathf.Clamp(damage, 0, maxHealth.value);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke(currentHealth, maxHealth.value);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.value);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke(currentHealth, maxHealth.value);
    }

    public virtual void Die()
    {

    }

    void OnChangedLevel()
    {
        maxHealth.OnLevelUp();
        Heal(maxHealth.value);
        damage.OnLevelUp();
        armor.OnLevelUp();
    }
}
