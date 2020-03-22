using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haz_script : MonoBehaviour
{
    int contador = 50;


    // Update is called once per frame
    void Update()
    {
        if (contador == 0)
        {
            contador = 50;
            gameObject.SetActive(false);
        }
        else
        {
            contador--;
        }
    }
}
