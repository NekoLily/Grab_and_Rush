﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Enum.GameState GameState;
    public static GameManager current;
    public int ScoreP1, ScoreP2, ScoreLimit; //Variable du score, limite du score fixée par les joueurs
    public float[,] Data = new float[2, 2] { { 1, 1 }, { 1, 1 } };
    public bool RunnerWin = true;
    public bool P1Run = true;
    // Use this for initialization
    private void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(this);
        }
        else if (current != this)
            Destroy(gameObject);
        GameState = Enum.GameState.MainMenu; //Lance le menu principal quand on allume le jeu
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState) //Permet de gérer le jeu selon son état GameState
        {
            case Enum.GameState.MainMenu: //Menu principal
                break;
            case Enum.GameState.BallSelect: //Selection de la boule/Skin, score max
                break;
            case Enum.GameState.GamePhaseP1Run: //Phase de jeu, le joueur 1 court
                P1Run = true;
                break;
            case Enum.GameState.GamePhaseP2Run: //Phase de jeu, le joueur 2 court
                P1Run = false;
                break;
            case Enum.GameState.MenuPause: //Menu pause en jeu
                break;
            case Enum.GameState.EndRound: //Fin du round, phase de transition et d'ajout au score
                if (RunnerWin)
                {
                    if (P1Run)
                        ScoreP1 += 1;
                    else
                        ScoreP2 += 1;
                }
                else if(RunnerWin == false)
                {
                    if (P1Run)
                        ScoreP2 += 1;
                    else
                        ScoreP1 += 1;
                }
                break;
            case Enum.GameState.Victory://Fin de la partie, afficher le score et recommencer/arreter de jouer
                break;
            case Enum.GameState.Credits: //Generique
                break;
            default:
                break;
        }
    }

    public void LoadScene(int ID_Scene)
    {
        switch (ID_Scene)
        {
            case 0:
                GameState = Enum.GameState.MainMenu;
                SceneManager.LoadScene("MenuPrincipale");
                break;

            case 1:
                GameState = Enum.GameState.GamePhaseP1Run;
                SceneManager.LoadScene("Jeu");
                break;
            case 2:
                GameState = Enum.GameState.Credits;
                SceneManager.LoadScene("Crédits");
                break;
        }
    }
}
