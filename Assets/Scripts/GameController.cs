using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;

    public float spawnWait;
    public float startWait;

    public float waivesWait;

    public GUIText scoreText;
    private int score;  // private Dosent show in function

    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText exitText;
    private bool gameOver; // Flags
    private bool restart;  // Flags

    // Use this for initialization
    void Start()
    {

        ////
        //
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen heigth : " + Screen.height);
        //
        ////


        // gameover restart
        gameOver = false;
        restart = false;
        gameOverText.text = ""; //At start Mt Display // GameOver
        restartText.text = "";  //At start Mt Display // Restart
        exitText.text = "";

        // Debug.Log(Time.time);
        score = 0;     // Initially Score on Game starts
        UpdateScore(); // Score on Screen

        
        StartCoroutine (SpawnWaves()); // Asteroid Waves

    }
    void Update()
    {
        // Restarts
        if (restart) // if restart is true after some time dx
        {
            if(Input.GetKeyDown(KeyCode.R) || Input.touchCount > 0) //  Touch and button
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.y > Screen.height / 2)
                {
                    Application.LoadLevel(Application.loadedLevel); // Loads Scean  // Restart
                }
                else
                {

                    Application.Quit();
                }
            }
        }

    }


    // Astroid Function !
    IEnumerator SpawnWaves()     // Not void if WaitForSeconds Exist !
    {
        yield return new WaitForSeconds(startWait); // When Game Starts Player Waits!

        while (true) // Infinite loop until gameOver (gameovers until vehicle destroys)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; // Rotation Zero
                Instantiate(hazard, spawnPostion, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waivesWait);// Wait between waves
            spawnWait = spawnWait - spawnWait / 30; // Increase the Astroid after every wave

            if (gameOver)
            {
                //restartText.text = "Press R for Restart";
                restartText.text = "Restart";
                exitText.text = "Exit";
                restart = true;
                break; // Ends the game
            }
        }
    }

    // Screen Score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

   public void AddScore(int newScoreValue)  // Use from other Foulders !
    {
        score += newScoreValue;
        UpdateScore();
    }


    // GameOver Function Public 
   public void GameOver()
    {
        gameOverText.text = "GameOver";
        //restartText.text = "Restart";
        //exitText.text = "Exit";
        gameOver = true;
    }
}
