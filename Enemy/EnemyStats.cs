using UnityEngine;

/*
Manages the enemys stats such as health
Written by Daniel Kasprzyk
*/

public class EnemyStats : MonoBehaviour
{
    public string enemyName;
    public float maxHealth;
    private float currentHealth;
    private bool isAlive = true;
    private GameObject thisEnemy;

    private void Start()
    {
        thisEnemy = this.transform.parent.gameObject;

        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive)
        {
            return;
        }

        currentHealth -= damage;
        print("Hit enemy: " + currentHealth + " / " + maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Destroy(thisEnemy);
        }
    }

    public void RefillHealth()
    {
        currentHealth = maxHealth;
    }
}
