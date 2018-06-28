using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountDown : MonoBehaviour
{
    public int timeLeft = 30;
    GameManager GM;
    bool CRRunning = false;
    public Text countdown;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
    void Update()
    {
        if(GM.GameState == Enum.GameState.GamePhaseP1Run || GM.GameState == Enum.GameState.GamePhaseP2Run)
        {
            if(CRRunning == false)
            {
                StartCoroutine("LoseTime");
            }
            countdown.text = ("" + timeLeft);
            if (timeLeft == 0)
            {
                StopCoroutine("LoseTime");
                CRRunning = false;
                GM.RunnerWin = true;
                GM.GameState = Enum.GameState.EndRound;
            }
        }
        else
        {
            timeLeft = 30;
            StopCoroutine("LoseTime");
        }
    }
            
    //Simple 
    IEnumerator LoseTime()
    {
        CRRunning = true;
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}