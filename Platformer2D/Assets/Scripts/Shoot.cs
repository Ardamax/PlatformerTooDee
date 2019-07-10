using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletSpawn;
    private float cooldown;
    public float fireRate;

    private void FixedUpdate()
    {
        bool shoot = Input.GetButton("Fire1");

        if (cooldown <= 0)
        {
            if (shoot)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                cooldown = fireRate;
            }
        } else
        {
            cooldown -= Time.deltaTime;
        }

    }
}
