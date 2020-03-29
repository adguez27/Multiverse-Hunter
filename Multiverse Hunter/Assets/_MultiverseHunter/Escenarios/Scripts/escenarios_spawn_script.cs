using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenarios_spawn_script : MonoBehaviour
{
    public List<GameObject> spawnList;
    private int size;
    public float spawnTime = 10f;
    private float spawnCounter;

    public bool isBossTime;
    public GameObject boss;
    public Vector3 bossPos = new Vector3(0, 3, 7);
    public Quaternion bossRot = new Quaternion(0, 0, 0, 0);
    public int limiteBoss;
    public bool hasBossSpawn;
    public GameObject polvo;
    private int contador = 1000;

    void Start()
    {
        polvo.SetActive(false);
        size = spawnList.Count;
        spawnCounter = spawnTime;
        for(int i=0; i<=10; i++)
        {
            int place = Random.Range(0, spawnList.Count);
            GameObject spawnLocation = spawnList[place];
            spawnLocation.GetComponent<escenarios_spawnController_scripts>().Spawn();
        }
        isBossTime = false;
        hasBossSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBossSpawn == false)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                int place = Random.Range(0, spawnList.Count);
                GameObject spawnLocation = spawnList[place];
                spawnLocation.GetComponent<escenarios_spawnController_scripts>().Spawn();
                spawnCounter = Random.Range(0, 4);
            }
        }
        if (hasBossSpawn == false)
        {
            // si isBossTime es true, se instancia al jefe de la ronda
            if (isBossTime == true)
            {
                if (contador > 0)
                {
                    polvo.SetActive(true);
                    contador--;
                }
                else
                {
                    polvo.SetActive(false);
                    GameObject bossInstance = Instantiate(boss, bossPos, bossRot) as GameObject;
                    hasBossSpawn = true;
                }
            }
        }
    }
}

