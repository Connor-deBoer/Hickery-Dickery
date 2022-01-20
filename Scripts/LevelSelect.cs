using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //input a string name for a level, and get unity to load that scene
    public void LevelSelectMethod(string levelText)
    {
        SceneManager.LoadScene(levelText);
    }
}
