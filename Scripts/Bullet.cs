using UnityEngine;

public class Bullet : MonoBehaviour
{
    //variables to control the bullets
    Rigidbody rb;
    public float speed;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        speed += Random.Range(speed, speed * 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.position += Vector3.left * speed * Time.deltaTime;
    }

    //resets the bullet when it hits a killer object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Killer")) gameObject.Death(startPos);
    }
}
