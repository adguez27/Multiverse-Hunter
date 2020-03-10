using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artículos_Salud_Script : MonoBehaviour
{
    public int salud = 50;
    public GameObject jugador;

    void Update()
    {
        if (Vector3.Distance(GameObject.Find("Jugador").transform.position, transform.position) < 2)
        {
            GameObject cuerpo = GameObject.Find("Jugador").transform.GetChild(0).gameObject;
            cuerpo.GetComponent<jugador_healthManager_script>().refrescarSalud(salud);
            Destroy(gameObject);
        }
    }
}
