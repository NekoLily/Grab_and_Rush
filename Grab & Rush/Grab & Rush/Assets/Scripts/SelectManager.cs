using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    GameManager _GameManager;
    public int Max_Skin = 8;

    public GameObject Arrow_P1;
    public GameObject Arrow_P2;

    GameObject P1_Player;
    GameObject P2_Player;

    GameObject P1_Hook;
    GameObject P2_Hook;

    float Axis_Value_P1;
    float Axis_Value_P2;

    float Index_Player_P1 = 1;
    float Index_Player_P2 = 1;

    private bool H_Axe_P1 = false;
    private bool H_Axe_P2 = false;

    private bool V_Axe_P1 = false;
    private bool V_Axe_P2 = false;

    private bool Selected_Player_Skin_P1 = false;
    private bool Selected_Player_Skin_P2 = false;

    private bool Selected_Hook_Skin_P1 = false;
    private bool Selected_Hook_Skin_P2 = false;

    private bool P1_IsReady = false;
    private bool P2_IsReady = false;

    public InputField ScoreInput;

    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        P1_Player = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P1), new Vector2(-2.5f, 1.5f), transform.rotation);
        P2_Player = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P2), new Vector2(2.5f, 1.5f), transform.rotation);

        P1_Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook_Skin/Hook_" + Index_Player_P1), new Vector2(-2.3f, -2f), transform.rotation);
        P2_Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook_Skin/Hook_" + Index_Player_P2), new Vector2(2.3f, -2f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Axis_Value_P1 = Input.GetAxisRaw("HorizontalP1")) != 0)
        {
            if (H_Axe_P1 == false)
            {
                if (Selected_Player_Skin_P1 == false)
                    SwitchPlayerSkin(Axis_Value_P1, 1);
                else if (Selected_Player_Skin_P1)
                    SwitchHookSkin(Axis_Value_P1, 1);
                H_Axe_P1 = true;
            }
        }
        if (Input.GetAxisRaw("HorizontalP1") == 0)
            H_Axe_P1 = false;


        if ((Axis_Value_P2 = Input.GetAxisRaw("HorizontalP2")) != 0)
        {
            if (H_Axe_P2 == false)
            {
                if (Selected_Player_Skin_P2 == false)
                    SwitchPlayerSkin(Axis_Value_P2, 2);
                else if (Selected_Player_Skin_P2)
                    SwitchHookSkin(Axis_Value_P2, 2);
                H_Axe_P2 = true;
            }
        }
        if (Input.GetAxisRaw("HorizontalP2") == 0)
            H_Axe_P2 = false;


        /////////////////////////////////////////////////////////////////

        if ((Axis_Value_P1 = Input.GetAxisRaw("VerticalP1")) != 0)
        {
            if (V_Axe_P1 == false)
            {
                if (Axis_Value_P1 > 0)
                {
                    if (Selected_Player_Skin_P1 == false)
                        Selected_Player_Skin_P1 = true;
                    else if (Selected_Hook_Skin_P1 == false)
                        Selected_Hook_Skin_P1 = true;
                }
                else if (Axis_Value_P1 < 0)
                {
                    if (Selected_Hook_Skin_P1 == true)
                        Selected_Hook_Skin_P1 = false;
                    else if (Selected_Player_Skin_P1 == true)
                        Selected_Player_Skin_P1 = false;

                }
                Debug.Log(Selected_Player_Skin_P1 + " " + Selected_Hook_Skin_P1);
                V_Axe_P1 = true;
            }
        }
        if (Input.GetAxisRaw("VerticalP1") == 0)
            V_Axe_P1 = false;


        if ((Axis_Value_P2 = Input.GetAxisRaw("VerticalP2")) != 0)
        {
            if (V_Axe_P2 == false)
            {
                if (Axis_Value_P2 > 0)
                {
                    if (Selected_Player_Skin_P2 == false)
                        Selected_Player_Skin_P2 = true;
                    else if (Selected_Hook_Skin_P2 == false)
                        Selected_Hook_Skin_P2 = true;
                }
                else if (Axis_Value_P2 < 0)
                {
                    if (Selected_Hook_Skin_P2 == true)
                        Selected_Hook_Skin_P2 = false;
                    else if (Selected_Player_Skin_P2 == true)
                        Selected_Player_Skin_P2 = false;

                }
                Debug.Log(Selected_Player_Skin_P2 + " " + Selected_Hook_Skin_P2);
                V_Axe_P2 = true;
            }
        }
        if (Input.GetAxisRaw("VerticalP2") == 0)
            V_Axe_P2 = false;

        ///////////////////////////////////////////////////////////////////

        if (Selected_Player_Skin_P1)
        {
            Arrow_P1.transform.position = new Vector3(-2.4f, -2, 0);
        }
        else
        {
            Arrow_P1.transform.position = new Vector3(-2.4f, 1.5f, 0);
        }
        if (Selected_Hook_Skin_P1)
        {
            Arrow_P1.transform.position = new Vector3(-2.4f, 10, 0);
        }
        else if (Selected_Player_Skin_P1)
        {
            Arrow_P1.transform.position = new Vector3(-2.4f, -2f, 0);
        }




        if (Selected_Player_Skin_P2)
        {
            Arrow_P2.transform.position = new Vector3(2.4f, -2, 0);
        }
        else
        {
            Arrow_P2.transform.position = new Vector3(2.4f, 1.5f, 0);
        }
        if (Selected_Hook_Skin_P2)
        {
            Arrow_P2.transform.position = new Vector3(2.4f, 10, 0);
        }
        else if (Selected_Player_Skin_P2)
        {
            Arrow_P2.transform.position = new Vector3(2.4f, -2f, 0);
        }


        ////////////////////////////////////////////////////////////////

    }

    void SwitchPlayerSkin(float Axis_Value, int Player)
    {
        switch (Player)
        {
            case 1:
                DestroyObject(P1_Player);
                if (Index_Player_P1 + Axis_Value_P1 < 1)
                    Index_Player_P1 = Max_Skin;
                else if (Index_Player_P1 + Axis_Value_P1 > 8)
                    Index_Player_P1 = 1;
                else
                    Index_Player_P1 += Axis_Value_P1;
                P1_Player = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P1), new Vector2(-2.5f, 1.5f), transform.rotation);
                _GameManager.GetComponent<GameManager>().Data[0, 0] = Index_Player_P1;
                break;
            case 2:
                DestroyObject(P2_Player);
                if (Index_Player_P2 + Axis_Value_P2 < 1)
                    Index_Player_P2 = Max_Skin;
                else if (Index_Player_P2 + Axis_Value_P2 > 8)
                    Index_Player_P2 = 1;
                else
                    Index_Player_P2 += Axis_Value_P2;
                P2_Player = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P2), new Vector2(2.5f, 1.5f), transform.rotation);
                _GameManager.GetComponent<GameManager>().Data[1, 0] = Index_Player_P2;
                break;
        }
    }

    void SwitchHookSkin(float Axis_Value, int Player)
    {
        switch (Player)
        {
            case 1:
                DestroyObject(P1_Hook);
                if (Index_Player_P1 + Axis_Value_P1 < 1)
                    Index_Player_P1 = Max_Skin;
                else if (Index_Player_P1 + Axis_Value_P1 > 8)
                    Index_Player_P1 = 1;
                else
                    Index_Player_P1 += Axis_Value_P1;
                P1_Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook_Skin/Hook_" + Index_Player_P1), new Vector2(-2.3f, -2), transform.rotation);
                _GameManager.GetComponent<GameManager>().Data[0, 1] = Index_Player_P1;
                break;
            case 2:
                DestroyObject(P2_Hook);
                if (Index_Player_P2 + Axis_Value_P2 < 1)
                    Index_Player_P2 = Max_Skin;
                else if (Index_Player_P2 + Axis_Value_P2 > 8)
                    Index_Player_P2 = 1;
                else
                    Index_Player_P2 += Axis_Value_P2;
                P2_Hook = Instantiate(Resources.Load<GameObject>("Prefab/Hook_Skin/Hook_" + Index_Player_P2), new Vector2(2.3f, -2), transform.rotation);
                _GameManager.GetComponent<GameManager>().Data[1, 1] = Index_Player_P2;
                break;
        }
    }


    public void StartGame()
    {
        if (Selected_Player_Skin_P1 && Selected_Player_Skin_P2 && Selected_Hook_Skin_P1 && Selected_Hook_Skin_P2)
        {
            if (ScoreInput.text != "" && ScoreInput.text != null)
                _GameManager.ScoreLimit = int.Parse(ScoreInput.text);
            else
                _GameManager.ScoreLimit = 5;
            _GameManager.LoadScene(2);
        }
    }
}
