using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jugador_healthManager_script : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public Slider barradeSalud;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        barradeSalud.maxValue = startingHealth;
        barradeSalud.value = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        barradeSalud.value -= damage;
    }

    public void refrescarSalud(int salud)
    {
        int sanacion = startingHealth - currentHealth;
        if (sanacion < salud)
        {
            currentHealth += sanacion;
            barradeSalud.value += sanacion;
        }
        else
        {
            currentHealth += salud;
            barradeSalud.value += salud;
        }
    }
}
