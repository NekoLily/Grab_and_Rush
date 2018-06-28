using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountDown : MonoBehaviour
{
    public int timeLeft = 60;
    public Text countdown;
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
    void Update()
    {
        countdown.text = ("" + timeLeft);
        if (timeLeft ==0 )
        {
            StopCoroutine("LoseTime");
        }
    }
    //Simple 
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}