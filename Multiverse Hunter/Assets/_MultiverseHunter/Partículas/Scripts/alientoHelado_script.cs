using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alientoHelado_script : MonoBehaviour
{
    public int daño = 5000;
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player2")
        {
            GameObject.Find("Jugador").GetComponentInChildren<jugador_healthManager_script>().currentHealth = 0;
        }
    }
}