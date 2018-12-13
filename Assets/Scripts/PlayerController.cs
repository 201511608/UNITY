using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry  
    // Class as a Structue
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    //public Rigidbody rb;
    public float speed; // Public we can see in Unity

    // Boundry
    public Boundry boundry;

    // Tilt Aeroplain
    public float tilt;

    // Firing Shot on Trigger
    public GameObject shot;
    public Transform shotSpawn;

    public float nextFire;
    public float fireRate;
    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //newProjectile = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;

            // create code here that animates the newProjectile
            //nextFire = nextFire - Time.time;
            //myTime = 0.0F;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        //Remember new in C# // f Floating Point Number
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement*speed;    // some Vector3 value;



        //Limiting Borders      
                // for Aeropalin
        rb.position = new Vector3(
                                Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax), // In xPosition minx maxx
                                0.0f,                                                   // In yposition miny maxy
                                Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)  // In zposition minz maxz
                                  );



        //Tilt player
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
//// Use this for initialization
//void Start () {

//}

//// Update is called once per frame
//void Update () {

//}