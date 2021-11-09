using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    
    float startTime;
    bool finished = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            return;
        }
        
        float time = Time.time - startTime;

        string minutes = ((int) time / 60).ToString(); 
        string seconds = (time % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Finish")
        {
            timerText.color = Color.yellow;
            finished = true;
        }
    }
}
