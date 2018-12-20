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

            // Fire Sound
            AudioSource Myaudio = GetComponent<AudioSource>();
            Myaudio.Play();
                //
            // create code here that animates the newProjectile
            //nextFire = nextFire - Time.time;
            //myTime = 0.0F;
        }

     
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal : " + moveHorizontal);
        Debug.Log("Horizontal : " + moveVertical);

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





        /////
        //
        // Touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //Debug.Log ("Right "+ laneWidth);
                //if (touch.position.x > Screen.width / 2)
                //{
                ////float dx = (8 / Screen.width) * touch.position.x;
                ////float dy = (18 / Screen.height) * touch.position.y;
                ////float x =  transform.position.x + dx;
                ////float y =  transform.position.y + dy;

                ////transform.position = new Vector3(dx,dy, transform.position.z);


                float width = (float)Screen.width / 2.0f;
                float height = (float)Screen.height / 2.0f;

                Vector2 pos = touch.position;
                pos.x = ((pos.x - width) / width) * 5;
                //pos.y = ((pos.y - height) / height);
                //pos.x = ((pos.x) / Screen.width)*8;
                pos.y = ((pos.y) / Screen.height) * 18;
                Vector3 position = new Vector3(pos.x, 0.0f, pos.y);

                // Position the cube.


          
                //Remember new in C# // f Floating Point Number
                movement = new Vector3(pos.x, 0.0f, pos.y);
                rb.velocity = movement * speed;    // some Vector3 value;
                rb.position = position;
                //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt / 10);
                //}
                //else
                //{
                //    float x = transform.position.x - 1f;

                //    transform.position = new Vector3(x, transform.position.y, transform.position.z);
                //}
                // Bullet fire on touch
                nextFire = Time.time + fireRate;
                //newProjectile = 

                // After touch one !
                if (Input.touchCount >= 2)
                {
                    touch = Input.GetTouch(1);
                    if (touch.phase == TouchPhase.Began)
                    {

                        Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;

                        // Fire Sound
                        AudioSource Myaudio = GetComponent<AudioSource>();
                        Myaudio.Play();
                    }
                }
            }
        }
        //
        /////

    }
}
//// Use this for initialization
//void Start () {

//}

//// Update is called once per frame
//void Update () {

//}