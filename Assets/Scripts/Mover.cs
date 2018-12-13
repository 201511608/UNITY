using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{
    public float speed;
    //Initial Run
    void Start()
    {
        // As soon as it start/triggers It must Move forword

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
