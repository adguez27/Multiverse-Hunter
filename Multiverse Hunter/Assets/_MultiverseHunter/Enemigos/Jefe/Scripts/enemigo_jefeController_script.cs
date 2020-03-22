using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_jefeController_script : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed;
    public float distance;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        GameObject follow = GameObject.FindGameObjectWithTag("Player");
        target = follow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position);
        //Look at target
        Vector3 dir = target.position - myTransform.position;
        dir.y = 0.0f;
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
    }
}
