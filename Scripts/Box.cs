using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector3 startPos;
    public AudioSource boxAudio;
    public AudioClip gFlipSFX;
    //boxes should be able to interact with things bby touching them
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Win")) gameObject.Death(startPos);

        if (collision.gameObject.CompareTag("GFlip")) GameElements.GravityFlip(boxAudio, gFlipSFX);
    }
}