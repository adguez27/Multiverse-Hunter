using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public Transform objetivo;
    public Transform disparador;
    public float velocidadDisparo = 4;
    public float aceleración = 3;
    public float fuerza = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position += disparador.transform.forward * Time.deltaTime * velocidadDisparo;
        /* Para emplear en caso de que se quiera hacer un arma con disparos teledirigidos */
        //transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, velocidadDisparo * Time.deltaTime);
        velocidadDisparo += aceleración * Time.deltaTime;
        aceleración += fuerza * Time.deltaTime;

        
        if (Vector3.Distance(transform.position, objetivo.transform.position) < 0.5f)
        {
            Destroy(gameObject);
            Destroy(GameObject.Find("Jugador"));
        }
    }
}
