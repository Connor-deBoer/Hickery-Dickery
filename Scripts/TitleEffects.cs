using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleEffects : MonoBehaviour
{
    public AudioClip yes;
    public AudioClip no;

    public float time;

    public GameObject titleText;
    public GameObject tutorial;
    public GameObject levelSelect;
    public GameObject quit;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToSpawn(time, tutorial, levelSelect, quit));
    }
    
    IEnumerator TimeToSpawn(float time, GameObject tutorial, GameObject levelSelect, GameObject quit)
    {
        yield return new WaitForSeconds(time);
        tutorial.SetActive(true);
        yield return new WaitForSeconds(time);
        levelSelect.SetActive(true);
        yield return new WaitForSeconds(time);
        quit.SetActive(true);
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    public void LevelSelect(GameObject levels)
    {
        gameObject.GetComponent<AudioSource>().clip = yes;
        gameObject.GetComponent<AudioSource>().Play();
        titleScreen.SetActive(false);
        levels.SetActive(true);
    }

    public void Back(GameObject levelSelect)
    {
        gameObject.GetComponent<AudioSource>().clip = no;
        gameObject.GetComponent<AudioSource>().Play();
        levelSelect.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void TutorialStart()
    {
        gameObject.GetComponent<AudioSource>().clip = yes;
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Level 1T");
    }

    public void Quit()
    {
        gameObject.GetComponent<AudioSource>().clip = no;
        gameObject.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
