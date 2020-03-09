using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador_healthManager_script : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public float flashLength;
    private float flashCounter;


    private Renderer rend;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<= 0)
        {
            gameObject.SetActive(false);
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
    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);
    }
}
