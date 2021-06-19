using UnityEngine;

/*
Manages the enemys stats such as health
Written by Daniel Kasprzyk
*/

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private bool isAlive = true;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive)
        {
            return;
        }

        currentHealth -= damage;
        print("Enemy hit for " + damage);
        print("Health: " + currentHealth + " / " + maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}
