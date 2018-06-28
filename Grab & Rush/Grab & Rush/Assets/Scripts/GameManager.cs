using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Enum.GameState GameState;
    public static GameManager current;
    public int ScoreP1, ScoreP2, ScoreLimit; //Variable du score, limite du score fixée par les joueurs
    public float[,] Data = new float[2, 2] { { 1, 1 }, { 1, 1 } };
    public bool RunnerWin = true;
    public bool P1Run = false;
    public bool ScoreAdded = false;
    public Text ScoreText;
    public Text EndRound;

    private bool EndRoundCRRunning = false;
    private Enum.GameState TMP;
    private GameObject Player;
    private GameObject CHENILLE;
    private GameObject Hook;
    private GameObject P1;
    private GameObject P2;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "MainMenu":
                    LoadScene(-1);
                    break;

                case "SelectMenu":
                    LoadScene(0);
                    break;

                case "Credits":
                    LoadScene(0);
                    break;

                case "Grab&Rush":                  
                    if (GameState != Enum.GameState.MenuPause)
                    {                    
                        TMP = GameState;
                        GameState = Enum.GameState.MenuPause;
                        GameObject.Find("Canvas").gameObject.transform.Find("Menu").gameObject.SetActive(true);
                        Time.timeScale = 0f;
                    }
                    else if (GameState == Enum.GameState.MenuPause)
                    {
                        GameObject.Find("Menu").SetActive(false);
                        GameState = TMP;
                        Time.timeScale = 1f;
                    }
                    break;
            }

        }
        switch (GameState) //Permet de gérer le jeu selon son état GameState
        {
            case Enum.GameState.MainMenu: //Menu principal
                break;
            case Enum.GameState.BallSelect: //Selection de la boule/Skin, score max
                break;
            case Enum.GameState.GamePhaseP1Run: //Phase de jeu, le joueur 1 court
                ScoreText = GameObject.Find("Score").GetComponent<Text>();
                ScoreText.text = ScoreP1.ToString() + " - " + ScoreP2.ToString();
                P1Run = true;
                ScoreAdded = false;

                break;
            case Enum.GameState.GamePhaseP2Run: //Phase de jeu, le joueur 2 court
                ScoreText = GameObject.Find("Score").GetComponent<Text>();
                ScoreText.text = ScoreP1.ToString() + " - " + ScoreP2.ToString();
                P1Run = false;
                ScoreAdded = false;

                break;
            case Enum.GameState.MenuPause: //Menu pause en jeu
                break;
            case Enum.GameState.EndRound: //Fin du round, phase de transition et d'ajout au score
                EndRound = GameObject.Find("EndRound").GetComponent<Text>();
                if (EndRoundCRRunning == false)
                    StartCoroutine(EndRoundCR());

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
                SceneManager.LoadScene("Score");
                break;
            case 4:
                GameState = Enum.GameState.Credits;
                SceneManager.LoadScene("Credits");
                break;
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        CHENILLE = Instantiate(Resources.Load<GameObject>("Prefab/LACHENILLE"));
        if (P1Run == false)
        {       
            Player = Instantiate(Resources.Load<GameObject>("Prefab/Player/Player_" + Data[0, 0]));
            Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook/Hook_" + Data[1, 1]));

            GameObject TMP = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Data[1, 0]));
            TMP.transform.localScale -= TMP.transform.localScale * 0.5f;
            TMP.transform.parent = Hook.transform.Find("Cabin");
            TMP.transform.position = GameObject.Find("Playerpos").transform.position;
            GameState = Enum.GameState.GamePhaseP1Run;
        }
        else
        {
            Player = Instantiate(Resources.Load<GameObject>("Prefab/Player/Player_" + Data[1, 0]));
            Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook/Hook_" + Data[0, 1]));

            GameObject TMP = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Data[0, 0]));
            TMP.transform.localScale -= TMP.transform.localScale * 0.5f;
            TMP.transform.parent = Hook.transform.Find("Cabin");
            TMP.transform.position = GameObject.Find("Playerpos").transform.position;
            GameState = Enum.GameState.GamePhaseP2Run;
        }
        GameObject.Find("Spawn").GetComponent<PlatformSpawn>().Spawn();
    }

    IEnumerator EndRoundCR()
    {
        EndRoundCRRunning = true;
        foreach (GameObject GO in GameObject.FindGameObjectsWithTag("Ground"))
            Destroy(GO);
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
            EndRound.text = ScoreP1.ToString() + " - " + ScoreP2.ToString();
            yield return new WaitForSeconds(1.5f);
            EndRound.text = "";
            if (ScoreP1 == ScoreLimit || ScoreP2 == ScoreLimit)
            {
                LoadScene(3);
                StartCoroutine("SetScore");
                GameState = Enum.GameState.Victory;
            }
            else if (P1Run)
            {
                StartCoroutine("SpawnPlayer");
            }
            else if (P1Run == false)
            {
                StartCoroutine("SpawnPlayer");
            }

            ScoreAdded = true;
        }
        EndRoundCRRunning = false;
    }

    IEnumerator SetScore()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("ScoreText").GetComponent<Text>().text = ScoreP1 + " - " + ScoreP2;
        if (ScoreP1 > ScoreP2)
        {
            P1 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Data[0, 0]), new Vector3(-2.5f, -2.2f, 0), transform.rotation);
            P1.transform.localScale += P1.transform.localScale * 0.5f;
            P2 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Data[1, 0]), new Vector3(1.5f, -1.5f, 0), transform.rotation);
            P2.transform.localScale -= P1.transform.localScale * 0.5f;
        }
        else
        {
            P1 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Data[0, 0]), new Vector3(-2.5f, -1.5f, 0), transform.rotation);
            P1.transform.localScale -= P1.transform.localScale * 0.5f;
            P2 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Data[1, 0]), new Vector3(1.5f, -2.2f, 0), transform.rotation);
            P2.transform.localScale += P1.transform.localScale * 0.5f;
        }
        ScoreP1 = 0;
        ScoreP2 = 0;
        P1Run = false;
    }
}
