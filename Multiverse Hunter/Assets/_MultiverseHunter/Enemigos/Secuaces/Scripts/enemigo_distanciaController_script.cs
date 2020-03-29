using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo_distanciaController_script : MonoBehaviour
{
    // Agente = Enemigo a Distancia
    public NavMeshAgent agente;

    // Objetivo = Jugador
    public Transform objetivo;

    // Última posición del jugador
    public Vector3 ultimaPosicionObjetivo;

    // Rango de ataque
    public float rango = 8;

    public int velocidadRotatoria = 2;

    // Máscara de capas que el enemigo puede distinguir
    public LayerMask layerMask;

    // Objeto proyectil
    public GameObject bala;

    public GameObject jugador;
    // Intervalo de tiempo entre lanzamiento de proyectiles
    private int time = 0;

    void Start()
    {
        jugador = GameObject.Find("Jugador");
        objetivo = jugador.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        // En un principio no ve al jugador (su enemigo)
        bool veAlEnemigo = false;

        // Se comprueba la distancia entre el jugador y el enemigo.
        Vector3 dir = objetivo.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), velocidadRotatoria * Time.deltaTime);
        // Se lanza un rayo
        RaycastHit hit;

        // En caso de que el rayo colisione con cualquier capa...
        if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, layerMask))
        {
            // se dibuja un rayo de color amarillo
            Debug.DrawRay(transform.position, dir.normalized * hit.distance, Color.yellow);

            // en caso de que esa capa sea el jugador, el enemigo ve al jugador (su enemigo)
            if (hit.transform.CompareTag("Player2")) veAlEnemigo = true;
        }
        else
        {
            // En caos contrario dibuja un rayo blanco hacía delante
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

        }


        // Si la distancia entre jugador y enemigo está fuera del rango de tiro de este último
        //o este último no ve al jugador
        if (Vector3.Distance(objetivo.position, transform.position) > rango || !veAlEnemigo)
        {
            // se comprueba la posición del jugador y substituye a la última conocida
            ultimaPosicionObjetivo = objetivo.position;

            // se manda al enemigo a dicha posición
            agente.SetDestination(ultimaPosicionObjetivo);

            // en caso de que el enemigo estubiese parado se lo vuelve a poner en movimiento
            agente.isStopped = false;
        }
        else
        {
            // en caso de que esté dentro del rango, el enemigó se posiciona para atacar
            agente.isStopped = true;
        }
    }
}