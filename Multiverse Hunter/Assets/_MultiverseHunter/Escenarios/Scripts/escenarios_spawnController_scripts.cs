using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenarios_spawnController_scripts : MonoBehaviour
{
    public GameObject polvo;
    public void Spawn()
    {
            polvo.SetActive(true);
    }
}
