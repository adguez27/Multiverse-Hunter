using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo_Melee : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform objetivo;
    public Vector3 ultimaPosicionObjetivo;

    // Update is called once per frame
    void Update()
    {
        if(ultimaPosicionObjetivo != objetivo.position)
        {
            ultimaPosicionObjetivo = objetivo.position;
            agente.SetDestination(ultimaPosicionObjetivo);
        }    
    }
}
