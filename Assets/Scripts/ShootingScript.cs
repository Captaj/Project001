using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    //Ammo in player inventory
    public int totalAmmo = 20;
    //ammo in gun
    public int curAmmo = 3;
    //Max gun Ammo
    public int maxAmmo = 3;
    //How fast the bullet is launched at
    public float bulletForce = 30f;
    //Empty Gun sound effect
    public GameObject emptyGunSound;
    //bullet sound
    public GameObject shootyShootShootSound;
    //It is what you think it is
    public float Volume;


    // Update is called once per frame
    void Update()
    {

        int reloadAmount;

        //AmmoCollectable ammo = ammo.GetComponent<Player>();
        //  if (giveAmmo = true)



        if (Input.GetKeyDown(KeyCode.R))
        {
            //checks to see if player has ammo
            if (totalAmmo > 0)
            {
                //Stores how much to reload
                reloadAmount = maxAmmo - curAmmo;
                if (reloadAmount > totalAmmo)
                {
                    reloadAmount = totalAmmo;
                }

                //takes reloaded bullets from inventory
                totalAmmo -= (reloadAmount);
                //sets current gun ammo
                curAmmo += reloadAmount;

            }

        }
        //Mouse click initiates weapon firing
        if (Input.GetButtonDown("Fire1"))
        {
            //checks if the gun has ammo
            if (curAmmo > 0)
            {

                //if the gun has ammo, the shoot script is set off
                Shoot();
            }

            else
            {
                //makes dryfire noise if no ammo in the gun
                Instantiate(emptyGunSound);

            }
        }
    }


    void Shoot()
    {
        //subtracts a bullet from the gun
        curAmmo -= 1;
        //Spawns the bullet at the firepoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //adds physics to the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //uses physics and launches the bullet
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        //destroys the bullet after 5 seconds so it doesn't cluttet the map
        Destroy(bullet, 5f);
        //Makes shooty shoot sounds
        Instantiate(shootyShootShootSound);


    }


}

