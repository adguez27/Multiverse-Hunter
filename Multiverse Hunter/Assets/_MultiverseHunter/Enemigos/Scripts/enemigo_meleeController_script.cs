using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_meleeController_script : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float rotationSpeed;
    private float distance;
    private Transform myTransform;
    void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start()
    {
        GameObject follow = GameObject.FindGameObjectWithTag("Player");
        target = follow.transform;
        distance = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position);
        //Look at target
        Vector3 dir = target.position - myTransform.position;
        dir.y = 0.0f;
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
        {
            //Move towards target
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
