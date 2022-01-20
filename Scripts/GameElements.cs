using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameElements
{
    public static bool grounded = true;

    /// <summary>
    /// Moves a Game Object via Rigidbody based on input
    /// </summary>
    /// <param name="rb"></param>
    /// <param name="speed">the speed the rigidbody moves</param>
    /// <param name="jumpForce">the power of the jump</param>
    public static void Move(this Rigidbody rb, Vector3 up, float speed, float jumpForce, float radius, AudioSource audio, AudioClip jumpSFX)
    {
        CheckGround(rb.position, radius);

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            audio.clip = jumpSFX;
            audio.Play();
            rb.AddForce(up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    /// <summary>
    /// checks to see if a game object is on the ground based on a sphere collider
    /// </summary>
    /// <param name="pos">position of collider</param>
    /// <param name="radius">radius of the collider</param>
    static void CheckGround(Vector3 pos, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, radius, LayerMask.GetMask("Ground"));
        if (colliders.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    /// <summary>
    /// turns any kinematic rigidbody into a conveyor belt, must be in a fixed update
    /// </summary>
    /// <param name="conveyRb"></param>
    /// <param name="direction">direction of the conveyor</param>
    /// <param name="speed">speed of the conveyor</param>
    public static void Convey(this Rigidbody conveyRb, Vector3 direction, float speed)
    {
        Vector3 pos = conveyRb.position;
        conveyRb.position -= direction * speed * Time.fixedDeltaTime;
        conveyRb.MovePosition(pos);
    }

    /// <summary>
    /// inverses the direction of gravity
    /// </summary>
    /// <param name="audio">the audio source that should play</param>
    /// <param name="gFlipSFX">the SFX that should play when the method is called</param>
    public static void GravityFlip(AudioSource audio, AudioClip gFlipSFX)
    {
        audio.clip = gFlipSFX;
        audio.Play();
        Physics.gravity = -Physics.gravity;
    }

    /// <summary>
    /// changes the size of an orthographic camera so that is can see a deterinmed amount of in game units
    /// </summary>
    /// <param name="mainCamera"></param>
    /// <param name="width">the width in world units that the camera can see</param>
    public static void WidthFit(this Camera mainCamera, float width)
    {
        mainCamera.orthographicSize = (width) / (2 * mainCamera.aspect);
    }

    /// <summary>
    /// changes current scene
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="scene">the name of the scene you would like to change to</param>
    public static void Win(this GameObject gameObject, string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// reloads the current scene when r is pressed
    /// </summary>
    public static void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// a method that reset a game object to a position
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="startPos">the position it responds to</param>
    public static void Death(this GameObject gameObject, Vector3 startPos)
    {
        Quaternion zero = new Quaternion(0, 0, 0, 0);

        gameObject.transform.position = startPos;
        gameObject.transform.rotation = zero;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    /// <summary>
    /// setting time scale to the delta of the mouse scroll wheel
    /// </summary>
    /// <param name="scale">the amount of time between each bump on the mouse wheel</param>
    public static void TimeControl(float scale)
    {
        if (Input.mouseScrollDelta.y < 0.0f) scale = 0f;
        Time.timeScale = Input.mouseScrollDelta.y * scale;
    }

    /// <summary>
    /// pouse the game and bring up a small menu
    /// </summary>
    /// <param name="pauseMenu">an object the get ser active when the method is called</param>
    /// <param name="audio">an audio source</param>
    /// <param name="pause">the SFX you want to play when the method is called</param>
    public static void Pause(GameObject pauseMenu, AudioSource audio, AudioClip pause)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audio.clip = pause;
            audio.Play();
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }       
    }
}