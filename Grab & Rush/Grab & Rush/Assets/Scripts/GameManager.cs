using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Enum.GameState GameState;
    public static GameManager current;
    public int Score, ScoreLimit; //Variable du score, limite du score fixée par les joueurs
    public int[,] Data = new int[1,1];
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
                break;
            case Enum.GameState.GamePhaseP2Run: //Phase de jeu, le joueur 2 court
                break;
            case Enum.GameState.MenuPause: //Menu pause en jeu
                break;
            case Enum.GameState.EndRound: //Fin du round, phase de transition et d'ajout au score
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
                SceneManager.LoadScene("MenuPrincipale");
                break;

            case 1:
                SceneManager.LoadScene("Jeu");
                break;
            case 2:
                SceneManager.LoadScene("Crédits");
                break;
        }
    }
}
