using UnityEngine;

/*
Used by the player to shoot in the game
Written by Daniel Kasprzyk
*/

public class Weapon : MonoBehaviour
{   
    public float damage;
    public float range;
    public int currentAmmoInMag;
    public int maxAmmoInMag;
    public int ammoReserve;
    private int ammoToDeduct;

    private bool readyToShoot;
    private bool shooting;
    private bool reloading;
    public float reloadTime;

    public Camera cam;
    public RaycastHit hit;
    public LayerMask layer;

    private void Awake()
    {
        //cam = GetComponentInParent<Camera>();
        Debug.Log(cam.transform.position);
        ammoReserve -= maxAmmoInMag;
        currentAmmoInMag = maxAmmoInMag;
        readyToShoot = true;
    }

    private void Update()
    {
        WeaponInput();
    }

    private void WeaponInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && currentAmmoInMag < maxAmmoInMag && !reloading)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && currentAmmoInMag > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, layer))
        {
            Debug.Log("yeah ray is out");
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("EnemyHit" + damage);
                hit.collider.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }

        currentAmmoInMag --;

        ammoToDeduct = maxAmmoInMag - currentAmmoInMag;

        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        //Ammo logic may have bugs

        //Reload when player has ammo in mag and additional reserve ammo
        if (currentAmmoInMag > 0 && ammoReserve >= ammoToDeduct )
        {
            //ammoToDeduct = totalMagSize - bulletsLeftInMag;
            ammoReserve -= ammoToDeduct;
            currentAmmoInMag = maxAmmoInMag;
        }

        //Reload when player loads last bullets into mag
        if (currentAmmoInMag > 0 && ammoReserve <= ammoToDeduct)
        {
            currentAmmoInMag += ammoReserve;
            ammoReserve = 0;
        }

        //Reload when player has no ammo in mag and reserve ammo
        if (currentAmmoInMag == 0 && ammoReserve > 0)
        {
            ammoReserve -= maxAmmoInMag;
            currentAmmoInMag = maxAmmoInMag;
        }

        reloading = false;
    }

    public bool AddAmmo(int ammoToReceive)
    {
        int updatedReserve;
        updatedReserve = ammoReserve + ammoToReceive;

        if (updatedReserve >= ammoReserve)
        {
            int ammoCheck = ammoReserve;
            ammoToReceive = ammoToReceive -= ammoReserve;
            ammoReserve += ammoToReceive;

            if (ammoCheck == ammoReserve)
            {
                return false;
            }

            else return true;
        }

        else if (updatedReserve < ammoReserve)
        {
            ammoReserve += ammoToReceive;
            return true;
        }

        else return false;
    }   
}
