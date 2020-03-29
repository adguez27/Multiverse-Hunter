using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigo_golemController_script : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;
    public float distance;
    private Transform myTransform;


    public NavMeshAgent agente;
    public Transform objetivo;
    public Vector3 ultimaPosicionObjetivo;
    public int daño = 150;

    public GameObject jugador;

    public GameObject aliento;
    public int duracionAliento = 500;
    public int recuperacionAliento = 500;
    void Awake()
    {
        myTransform = transform;
        aliento.SetActive(false);
    }

    void Start()
    {
        GameObject follow = GameObject.FindGameObjectWithTag("Player");
        target = follow.transform;
        jugador = GameObject.Find("Jugador");
        objetivo = jugador.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Pierna 1") == null && GameObject.Find("Pierna 2") == null)
        {
            if (GameObject.Find("Cuerpo_Golem") == null)
            {
                Debug.DrawLine(target.position, myTransform.position);
                //Look at target
                Vector3 dir = target.position - myTransform.position;
                dir.y = 0.0f;
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

                if (duracionAliento != 0)
                {
                    aliento.SetActive(true);
                    duracionAliento--;
                }
                else
                {
                    if (recuperacionAliento != 0)
                    {
                        aliento.SetActive(false);
                        recuperacionAliento--;
                    }
                    else
                    {
                        aliento.SetActive(true);
                        recuperacionAliento = 500;
                        duracionAliento = 500;
                    }
                }
            }
            else
            {
                GameObject.Find("Cuerpo_Golem").GetComponent<Rigidbody>().isKinematic = false;
                GameObject.Find("Cabeza").GetComponent<Rigidbody>().isKinematic = false;
                GameObject.Find("Puño 1").GetComponent<enemigo_golemAtaque_script>().modoAtaque = true;
                GameObject.Find("Puño 2").GetComponent<enemigo_golemAtaque_script>().modoAtaque = true;
                Debug.DrawLine(target.position, myTransform.position);
                //Look at target
                Vector3 dir = target.position - myTransform.position;
                dir.y = 0.0f;
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            }
    }
        else
        {
            if ((Vector3.Distance(objetivo.position, transform.position) - 3.4) > 0)
            {
                Debug.Log(Vector3.Distance(objetivo.position, transform.position));
                ultimaPosicionObjetivo = objetivo.position;
                agente.SetDestination(ultimaPosicionObjetivo);
                agente.isStopped = false;
            }
            else
            {
                agente.isStopped = true;
                GameObject.Find("Jugador").GetComponentInChildren<jugador_healthManager_script>().HurtPlayer(daño);
            }
        }
    }
}
