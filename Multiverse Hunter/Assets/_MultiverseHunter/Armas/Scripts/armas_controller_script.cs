using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armas_controller_script : MonoBehaviour
{
    public bool isFiring;
    public GameObject bullet;
    public float BulletSpeed = 30;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (isFiring == true)
        {
            
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
                balas_controller_script controller = (balas_controller_script)newBullet.GetComponent("balas_controller_script");
                controller.speed = BulletSpeed;
            }
            
        }
    }
}
