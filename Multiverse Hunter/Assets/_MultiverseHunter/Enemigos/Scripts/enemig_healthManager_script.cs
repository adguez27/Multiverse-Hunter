using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemig_healthManager_script : MonoBehaviour
{
    public int health;
    public int currentHealth;
    private float flashLength = 0.15f;
    private float flashCounter;
    private Renderer rend;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", originalColor);
            }
        }
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }
}
