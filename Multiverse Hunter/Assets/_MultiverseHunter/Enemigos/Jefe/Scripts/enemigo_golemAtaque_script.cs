﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_golemAtaque_script : MonoBehaviour
{
    public GameObject bullet;
    public float BulletSpeed = 30;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public float damage = 300;
    public float critChance = 5f;
    public float critDamage = 1.5f;
    public bool modoAtaque;

    // Start is called before the first frame update
    void Start()
    {
        modoAtaque = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (modoAtaque == true)
        {


            shotCounter -= Time.deltaTime;


            if (shotCounter <= 0)
            {
                Shoot();
            }
        }


    }

    void Shoot()
    {
        timeBetweenShots = Random.Range(1, 2.5f);
        shotCounter = timeBetweenShots;
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        enemigo_balas_script controller = (enemigo_balas_script)newBullet.GetComponent("enemigo_balas_script");
        controller.speed = BulletSpeed;
        if (Random.Range(0f, 100f) <= critChance)
        {

            controller.damage = (int)(damage * critDamage);


        }
        else
        {
            controller.damage = (int)damage;

        }


    }
}
