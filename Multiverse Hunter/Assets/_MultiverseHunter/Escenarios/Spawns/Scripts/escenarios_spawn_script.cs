using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenarios_spawn_script : MonoBehaviour
{
    public List<GameObject> spawnList;
    private int size;
    public float spawnTime = 10f;
    private float spawnCounter;
    void Start()
    {
        size = spawnList.Count;
        spawnCounter = spawnTime;
        for(int i=0; i<=10; i++)
        {
            int place = Random.Range(0, spawnList.Count);
            GameObject spawnLocation = spawnList[place];
            spawnLocation.GetComponent<escenarios_spawnController_scripts>().Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            int place = Random.Range(0, spawnList.Count);
            GameObject spawnLocation = spawnList[place];
            spawnLocation.GetComponent<escenarios_spawnController_scripts>().Spawn();
            spawnCounter = Random.Range(2, 5);
        }
    }
    }

