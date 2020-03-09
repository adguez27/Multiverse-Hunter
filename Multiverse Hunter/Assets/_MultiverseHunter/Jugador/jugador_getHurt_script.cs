using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador_getHurt_script : MonoBehaviour
{
    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
            other.gameObject.GetComponent<jugador_healthManager_script>().HurtPlayer(damage);
        }
    }

}
