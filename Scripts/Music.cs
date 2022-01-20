using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;
    //don't destroy on load so music play continuously through out the game
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    //plays music
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
}
