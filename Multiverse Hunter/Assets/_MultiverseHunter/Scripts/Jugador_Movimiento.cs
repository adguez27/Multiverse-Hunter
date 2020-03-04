using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Movimiento : MonoBehaviour
{
    public float velocidad = 8f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            Moverse(new Vector2(0, 1));
        }
        if (Input.GetKey("down"))
        {
            Moverse(new Vector2(0, -1));
        }
        if (Input.GetKey("left"))
        {
            Moverse(new Vector2(-1, 0));
        }
        if (Input.GetKey("right"))
        {
            Moverse(new Vector2(1, 0));
        }
        transform.rotation = Quaternion.identity;
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void Moverse(Vector2 direccion)
    {
        transform.Translate(new Vector3(direccion.x, 0, direccion.y) * Time.deltaTime * velocidad);
    }
}
