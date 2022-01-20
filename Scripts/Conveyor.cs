using UnityEngine;

public class Conveyor : MonoBehaviour
{
    //variables to control the direction and speed of the conveyor
    public Rigidbody rb;
    public Vector3 direction;
    public float speed;
    
    //fixed update for a convey extension method
    void FixedUpdate()
    {
        rb.Convey(direction, speed);
    }
}