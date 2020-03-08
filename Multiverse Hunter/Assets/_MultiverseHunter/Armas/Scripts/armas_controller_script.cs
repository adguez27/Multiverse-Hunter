using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armas_controller_script : MonoBehaviour
{
    public bool isFiring;
    public GameObject bullet;
    public float BulletSpeed = 30;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public float maxAmmo = 30;
    public float reserveAmmo = 60;
    public float currentAmmo = 30;
    public float damage = 800;
    public float critChance = 5f;
    public float critDamage = 1.5f;
    public float reloadTime = 1f;
    public float reloadCounter = 1f;

    public Text textoMunición;
    // Start is called before the first frame update
    void Start()
    {
       textoMunición.text = currentAmmo.ToString() + "/" + reserveAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        reloadCounter -= Time.deltaTime;
        shotCounter -= Time.deltaTime;
        if (reloadCounter <= 0)
        {
            
            if (isFiring == true)
            {

                if (shotCounter <= 0 && currentAmmo >= 1)
                {
                    Shoot();
                    textoMunición.text = currentAmmo.ToString() + "/" + reserveAmmo.ToString();
                }

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
                textoMunición.text = currentAmmo.ToString() + "/" + reserveAmmo.ToString();
            }
        }
    }
    void Shoot()
    {
       
        shotCounter = timeBetweenShots;
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        balas_controller_script controller = (balas_controller_script)newBullet.GetComponent("balas_controller_script");
        controller.speed = BulletSpeed;
        if (Random.Range(0f, 100f) <= critChance)
        {
            
            controller.damage = (int) (damage * critDamage);
           
           
        }
        else
        {
            controller.damage = (int)damage;
            Debug.DrawLine(newBullet.transform.position, newBullet.transform.position, Color.blue);
        }
       
        currentAmmo -= 1;
    }
    void Reload()
    {
        reloadCounter = reloadTime;
        if (currentAmmo == 0)
        {
            if (reserveAmmo >= maxAmmo)
            {
                currentAmmo = maxAmmo;
                reserveAmmo -= maxAmmo;
            }
            else
            {
                currentAmmo = reserveAmmo;
                reserveAmmo = 0;
            }
        }
        else
        {
            float ammoNeeded = maxAmmo - currentAmmo;
            if(reserveAmmo >= ammoNeeded)
            {
                currentAmmo = maxAmmo;
                reserveAmmo -= ammoNeeded;
            }
            else
            {
                currentAmmo += reserveAmmo;
                reserveAmmo = 0;
            }
        }
    }

    public void refrescarMunición(float munición)
    {
        reserveAmmo += munición;
        textoMunición.text = currentAmmo.ToString() + "/" + reserveAmmo.ToString();
    }
}
