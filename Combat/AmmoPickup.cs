using UnityEngine;

/*
Adds ammo to the players weapon
Written by Daniel Kasprzyk
*/

public class AmmoPickup : MonoBehaviour
{
    public int ammoToAdd;
    private Weapon weapon;

    private void Awake()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //weapon.AddAmmo(ammoToAdd);
            //Destroy(gameObject);
            if (weapon.AddAmmo(ammoToAdd))
            {
                Destroy(gameObject);
            }

            else print("Ammo already full");
        }
    }
}
