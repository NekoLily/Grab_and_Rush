using System.Collections;
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
    public bool P1Run = false;
    public bool ScoreAdded = false;

    private GameObject Player;
    private GameObject Hook;
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
                ScoreAdded = false;

                break;
            case Enum.GameState.GamePhaseP2Run: //Phase de jeu, le joueur 2 court
                P1Run = false;
                ScoreAdded = false;
                
                break;
            case Enum.GameState.MenuPause: //Menu pause en jeu
                break;
            case Enum.GameState.EndRound: //Fin du round, phase de transition et d'ajout au score
                DestroyObject(Hook);
                DestroyObject(Player);
                if (ScoreAdded == false)
                {
                    if (RunnerWin)
                    {
                        if (P1Run)
                            ScoreP1 += 1;
                        else
                            ScoreP2 += 1;
                    }
                    else if (RunnerWin == false)
                    {
                        if (P1Run)
                            ScoreP2 += 1;
                        else
                            ScoreP1 += 1;
                    }

                    if (ScoreP1 == ScoreLimit || ScoreP2 == ScoreLimit)
                    {
                        GameState = Enum.GameState.Victory;
                    }
                    else if (P1Run)
                    {
                        StartCoroutine("SpawnPlayer");
                        //GameState = Enum.GameState.GamePhaseP2Run;
                    }
                    else if (P1Run == false)
                    {
                        StartCoroutine("SpawnPlayer");
                        //GameState = Enum.GameState.GamePhaseP1Run;
                    }

                    ScoreAdded = true;
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
            case -1:
                Application.Quit();
                break;
            case 0:
                GameState = Enum.GameState.MainMenu;
                Data = new float[2, 2] { { 1, 1 }, { 1, 1 } };
                SceneManager.LoadScene("MenuPrincipal");
                break;
            case 1:
                Data = new float[2, 2] { { 1, 1 }, { 1, 1 } };
                SceneManager.LoadScene("SelectMenu");
                break;
            case 2:
                GameState = Enum.GameState.Loading;
                SceneManager.LoadScene("Grab&Rush");
                StartCoroutine("SpawnPlayer");
                break;
            case 3:
                GameState = Enum.GameState.Credits;
                SceneManager.LoadScene("Credits");
                break;
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        if (P1Run == false)
        {
            Player =Instantiate(Resources.Load<GameObject>("Prefab/Player/Player_" + Data[0, 0]));
            Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook/Hook_" + Data[1, 1]));
            GameState = Enum.GameState.GamePhaseP1Run;
        }
        else
        {
            Player = Instantiate(Resources.Load<GameObject>("Prefab/Player/Player_" + Data[1, 0]));
            Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook/Hook_" + Data[0, 1]));
            GameState = Enum.GameState.GamePhaseP2Run;
        }

    }
}
