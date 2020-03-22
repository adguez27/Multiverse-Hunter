using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador_scoreManager_script : MonoBehaviour
{
    public int puntuacion;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;

        //declaramos isBossTime como false y la variable puntuación del script del jugador como 0
    }

    // Update is called once per frame
    void Update()
    {
       
            //si los puntos son iguales o superan a los requeridos, la variable isBossTime pasa a ser true
            if (puntuacion >= spawn.GetComponent<escenarios_spawn_script>().limiteBoss)
            {
                spawn.GetComponent<escenarios_spawn_script>().isBossTime = true;
            }
       
       

     

    }
}
