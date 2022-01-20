using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEffects : MonoBehaviour
{
    public GameObject firstMsg;
    public GameObject secondMsg;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeBetweenText(2, secondMsg, firstMsg));
    }
    
    public IEnumerator TimeBetweenText(float time, GameObject turnOn, GameObject turnOff)
    {
            yield return new WaitForSeconds(time);
            turnOn.SetActive(false);
            turnOff.SetActive(false);
    }



}
