using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;

    public int timer = 10;

    private void Start()
    {
        StartCoroutine(TimerCoroution());
    }

    IEnumerator TimerCoroution()
    {
        timer -= 1;

        timerText.text =  (timer / 60 % 60).ToString("D2") + ":" + (timer % 60).ToString("D2");

        yield return new WaitForSeconds(1f);

        StartCoroutine(TimerCoroution());
        if(timer<0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}


