using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //gravity flip variable
    public AudioClip gFlipSFX;

    //pause menu variables
    public AudioClip pauseSFX;
    public GameObject pauseMenu;

    //camera variables
    public float cameraWidth;
    public Camera mainCamera;

    //a string for the next scene
    public string nextScene;

    //jump variables
    public AudioClip jumpSFX;
    public float jumpForce;
    public GameObject up;
    public GameObject origin;
    public float radius;
    
    //essential movement variables
    public float speed;
    public float timeScale;

    //private variables for reference to components on the game object
    Rigidbody playerRb;
    AudioSource playerAudio;
    Vector3 startPos;
    Vector3 upDirection;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // determining which way is up for the player
        upDirection = up.transform.position - origin.transform.position;

        //time control
        GameElements.TimeControl(timeScale);

        //menu stuff
        GameElements.Pause(pauseMenu, playerAudio, pauseSFX);
        GameElements.Restart();
        
        //movement and camera stuff
        playerRb.Move(upDirection, speed, jumpForce, radius, playerAudio, jumpSFX);
        mainCamera.WidthFit(cameraWidth);
    }

    //depending what the player touches the game needs to do different things
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            Physics.gravity = new Vector3(0, -10f, 0);
            gameObject.Death(startPos);
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            Physics.gravity = new Vector3(0, -10f, 0);
            gameObject.Win(nextScene);
        }

        if (collision.gameObject.CompareTag("GFlip"))
        {
            GameElements.GravityFlip(playerAudio, gFlipSFX);
        }
    }
}
