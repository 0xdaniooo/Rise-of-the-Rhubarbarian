using System.Collections;
using UnityEngine.UI;
using UnityEngine;

/*
Manages the players stats such as health
Written by Daniel Kasprzyk
*/

public class PlayerStats : MonoBehaviour
{
    //Life variables
    public bool isAlive = true;
    private float currentHealth;
    public float maxHealth;
    public Slider healthbar;
    public float timeBeforeRegen = 10f;
    public float regenHealthTick = 1f;
    private Coroutine healthRegen;
    private WaitForSeconds healthTick; //= new WaitForSeconds(regenHealthTick);

    private void Start()
    {
        //Set health
        currentHealth = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;

        healthTick = new WaitForSeconds(regenHealthTick);
    }

    private IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(timeBeforeRegen);

        while (currentHealth < maxHealth)
        {
            currentHealth += maxHealth / 100;
            healthbar.value = currentHealth;
            yield return healthTick;
        }

        healthRegen = null;
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive)
        {
            return;
        }

        currentHealth -= damage;
        healthbar.value = currentHealth;

        if (healthRegen != null)
        {
            StopCoroutine(healthRegen);
        }

        if (currentHealth > 0)
        {
            healthRegen = StartCoroutine(RegenHealth());
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            print("Player died");
        }
    }
}
