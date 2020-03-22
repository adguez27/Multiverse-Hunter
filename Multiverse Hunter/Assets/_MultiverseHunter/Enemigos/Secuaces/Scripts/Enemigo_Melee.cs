using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo_Melee : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform objetivo;
    public Vector3 ultimaPosicionObjetivo;
    public float rango = 5;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(objetivo.position, transform.position) > rango)
        {
            ultimaPosicionObjetivo = objetivo.position;
            agente.SetDestination(ultimaPosicionObjetivo);
            agente.isStopped = false;
        }
        else
        {
            agente.isStopped = true;
            Destroy(GameObject.Find("Jugador"));
        }
    }
}
