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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        barradeSalud.maxValue = health;
        barradeSalud.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SoltarObjeto();
            Destroy(gameObject);
        }
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        barradeSalud.value -= damage;
    }

    public void SoltarObjeto()
    {
        int valorAleatorio = Random.Range(0, 100);

        if (valorAleatorio >= 0 && valorAleatorio <= 50)
        {
            Instantiate(botiquín, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(munición, transform.position, Quaternion.identity);
        }
    }
}
