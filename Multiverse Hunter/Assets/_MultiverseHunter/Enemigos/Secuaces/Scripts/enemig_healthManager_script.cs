using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemig_healthManager_script : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public GameObject botiquín;
    public GameObject munición;
    public Slider barradeSalud;

    public GameObject sangre;

    private float flashLength = 0.15f;
    private float flashCounter;
    private Renderer rend;
    private Color originalColor;

    private int contador = 0;
    public int points;

    public GameObject portador;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        barradeSalud.maxValue = health;
        barradeSalud.value = health;
        barradeSalud.gameObject.SetActive(false);
        sangre.gameObject.SetActive(false);

        rend = GetComponent<Renderer>();
        originalColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (contador == 0)
        {
            barradeSalud.gameObject.SetActive(false);
            contador = 50;
        }
        else
        {
            contador--;
        }

        if (currentHealth <= 0)
        {
            barradeSalud.gameObject.SetActive(false);
            SoltarObjeto();
            Destroy(portador);
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                sangre.gameObject.SetActive(false);
                rend.material.SetColor("_Color", originalColor);
            }
        }
    }
    public void HurtEnemy(int damage)
    {
        sangre.gameObject.SetActive(true);
        barradeSalud.gameObject.SetActive(true);
        contador = 50;
        currentHealth -= damage;
        barradeSalud.value -= damage;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }

    public void SoltarObjeto()
    {
        int valorAleatorio = Random.Range(0, 100);

        if (valorAleatorio >= 0 && valorAleatorio <= 10)
        {
            Instantiate(botiquín, transform.position, Quaternion.identity);
        }
        else if (valorAleatorio >= 77 && valorAleatorio <= 100)
        {
            Instantiate(munición, transform.position, Quaternion.identity);
        }
    }
}
