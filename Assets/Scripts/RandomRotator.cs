using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    public float tumble;

    void Start()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();

        // Astroid Rotation
        rb.angularVelocity = Random.insideUnitSphere * tumble;

    }


}
