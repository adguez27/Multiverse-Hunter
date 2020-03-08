using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo_meleeController_script : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform objetivo;
    public Vector3 ultimaPosicionObjetivo;
    public int daño = 150;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(objetivo.position, transform.position) != 0)
        {
            ultimaPosicionObjetivo = objetivo.position;
            agente.SetDestination(ultimaPosicionObjetivo);
            agente.isStopped = false;
        }
        else
        {
            agente.isStopped = true;
            GameObject.Find("Jugador").GetComponent<jugador_healthManager_script>().HurtPlayer(daño);
        }
    }
}
