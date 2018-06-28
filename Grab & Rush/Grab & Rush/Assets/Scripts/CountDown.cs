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
       // StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
    void Update()
    {
        Debug.Log(CRRunning);
        if(GM.GameState == Enum.GameState.GamePhaseP1Run || GM.GameState == Enum.GameState.GamePhaseP2Run)
        {
            if(CRRunning == false)
            {
                StartCoroutine("LoseTime");
                CRRunning = true;
            }
            countdown.text = (timeLeft.ToString());
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
            CRRunning = false;
            StopCoroutine("LoseTime");
        }
    }
            
    //Simple 
    IEnumerator LoseTime()
    {
        CRRunning = true;
        while (true)
        {
            Debug.Log("GoesThere");
            yield return new WaitForSeconds(1f);
            timeLeft--;
            if(timeLeft == 0)
            {
                CRRunning = false;
                StopCoroutine(LoseTime());
                break;
            }
            
        }
    }
}