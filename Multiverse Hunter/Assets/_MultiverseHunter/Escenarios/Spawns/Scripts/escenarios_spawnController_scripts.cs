using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenarios_spawnController_scripts : MonoBehaviour
{
    public List<GameObject> EnemyTypes;
 
    public void Spawn()
    {
        int type = Random.Range(0, EnemyTypes.Count);
        GameObject enemy = Instantiate(EnemyTypes[type], this.transform.position, this.transform.rotation) as GameObject;
    }
}
