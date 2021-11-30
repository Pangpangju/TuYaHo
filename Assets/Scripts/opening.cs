using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opening : MonoBehaviour
{
    float timer;
    int waitingTime;

    void Start()
    {
        timer = 0;
        waitingTime = 4;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            SceneManager.LoadScene("Main");
            
        }
    }
}
