using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polvo_script : MonoBehaviour
{
    public List<GameObject> EnemyTypes;
    int contador = 40;
    // Update is called once per frame
    void Update()
    {
        if (contador == 0)
        {
            int type = Random.Range(0, EnemyTypes.Count);
            GameObject enemy = Instantiate(EnemyTypes[type], this.transform.position, this.transform.rotation) as GameObject;
            contador = 40;
            gameObject.SetActive(false);
        }
        else
        {
            contador--;
        }
    }
}
