using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundryAst
{
    public float xMin, xMax, zMin, zMax;
}



public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject PlayerExplosion;

    private GameController gameController;
    private int scoreValue=10;

    public BoundryAst boundry;

    void Start()
    {
     

    //Score Update on start this !
    //Point to Specifc Instance of Specific Class
    GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject !=null) // If Instance there
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null) // If Instance Not there // Safe side !!!
        {
            Debug.Log("GameController Instance Not Triggered/Found");
        }


    }

    void FixedUpdate()
    {
        // Asteriod fixing the Plane

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        //Remember new in C# // f Floating Point Number

        //Limiting Borders      
        // for Aeropalin
        rb.position = new Vector3(
                                Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax), // In xPosition minx maxx
                                0.0f,                                                   // In yposition miny maxy
                                Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax)  // In zposition minz maxz
                                  );

    }


    // On Contact Destroy other object
    void OnTriggerEnter(Collider other)
    {
        // Skyp the Boundry Condition
        if(other.tag=="Boundry" || other.tag == "Asteroid" || other.tag=="prop_asteroid_01")
        {
            return;
        }
        //Debug.Log(other.name);
        if(other.tag=="Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);// Player Explostion   > // Other Object transform data
            gameController.GameOver();
        }
        //Score Update on trigger destroy
        gameController.AddScore(scoreValue);// Calling function from gameControllerGAmeinstance;

        // Explostion Instantiate
        Instantiate(explosion, transform.position, transform.rotation); // Self transform data i.e Asteroid :PostionRotation.
        // Objects to get Destroyed
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

   
}
	
	
 