using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    GameManager _GameManager;
    public int Max_Skin = 8;
    GameObject P1;
    GameObject P2;

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

    void Start()
    {
        //_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        P1 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P1), new Vector2(-5, 0), transform.rotation);
        P2 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P2), new Vector2(5, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Axis_Value_P1 = Input.GetAxisRaw("HorizontalP1")) != 0)
        {
            if (H_Axe_P1 == false)
            {
                if (Selected_Player_Skin_P1 == false)
                    SwitchSkin(Axis_Value_P1, 1);
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
                    SwitchSkin(Axis_Value_P2, 2);
                H_Axe_P2 = true;
            }
        }
        if (Input.GetAxisRaw("HorizontalP2") == 0)
            H_Axe_P2 = false;

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

        if (Selected_Player_Skin_P1)
            P1.transform.position = new Vector2(-6, 3);
        else
            P1.transform.position = new Vector2(-5, 0);

    }

    void SwitchSkin(float Axis_Value, int Player)
    {
        switch (Player)
        {
            case 1:
                DestroyObject(P1);
                if (Index_Player_P1 + Axis_Value_P1 < 1)
                    Index_Player_P1 = Max_Skin;
                else if (Index_Player_P1 + Axis_Value_P1 > 8)
                    Index_Player_P1 = 1;
                else
                    Index_Player_P1 += Axis_Value_P1;
                P1 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P1), new Vector2(-5, 0), transform.rotation);
                break;
            case 2:
                DestroyObject(P2);
                if (Index_Player_P2 + Axis_Value_P2 < 1)
                    Index_Player_P2 = Max_Skin;
                else if (Index_Player_P2 + Axis_Value_P2 > 8)
                    Index_Player_P2 = 1;
                else
                    Index_Player_P2 += Axis_Value_P2;
                P2 = Instantiate(Resources.Load<GameObject>("Prefab/Player_Skin/Player_" + Index_Player_P2), new Vector2(5, 0), transform.rotation);
                break;
        }
    }

}
