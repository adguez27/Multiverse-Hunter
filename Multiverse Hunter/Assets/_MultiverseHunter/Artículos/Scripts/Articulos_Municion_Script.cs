using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Articulos_Municion_Script : MonoBehaviour
{
    public float munición = 50;

    void Update()
    {
        if (Vector3.Distance(GameObject.Find("Jugador").transform.position, transform.position) < 2)
        {
            GameObject cuerpo = GameObject.Find("Jugador").transform.GetChild(0).gameObject;
            GameObject arma = cuerpo.transform.GetChild(0).gameObject;
            arma.GetComponent<armas_controller_script>().refrescarMunición(munición);
            Destroy(gameObject);
        }
    }
}
