using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemigo_Distancia : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform objetivo;
    public Vector3 ultimaPosicionObjetivo;

    public float rango = 8;


    public LayerMask layerMask;

    public GameObject bala;

    private int time = 0;
    // Update is called once per frame
    void Update()
    {
        bool veAlEnemigo = false;

        Vector3 dir = objetivo.transform.position - transform.position;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, dir.normalized * hit.distance, Color.yellow);

            if (hit.transform.CompareTag("Player")) veAlEnemigo = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

        }

        if (Vector3.Distance(objetivo.position, transform.position) > rango || !veAlEnemigo)
        {
            ultimaPosicionObjetivo = objetivo.position;
            agente.SetDestination(ultimaPosicionObjetivo);
            agente.isStopped = false;
        }
        else
        {
            agente.isStopped = true;
            Disparar();
        }
    }

    public void Disparar()
    {
        if (time == 0)
        {
            GameObject misil = Instantiate(bala, transform.position, Quaternion.identity);
            misil.GetComponent<Misil>().objetivo = objetivo;
            misil.GetComponent<Misil>().disparador = transform;
            time = 50;
            Destroy(misil, 10f);
        }
        else
        {
            time--;
        }
    }
}
