﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas_controller_script : MonoBehaviour
{
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
}