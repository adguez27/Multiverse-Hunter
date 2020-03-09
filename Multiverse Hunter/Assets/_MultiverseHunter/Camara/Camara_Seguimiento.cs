using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Seguimiento : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset;
    public float retraso = .125f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + offset;
        Vector3 posicionRetrasada = Vector3.Lerp(transform.position, posicionDeseada, retraso);
        transform.position = posicionRetrasada;
    }
}
