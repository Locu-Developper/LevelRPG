using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Inventory
{
    //      ゲームオブジェクト
    public GameObject   Helmet, ChestPlate, RightHand, LeftHand, Leggings, Boots;
    public Slider pHPBer;
    public bool sInit, StatusWinBool;
    public int StatusWinNum = 999, ArmorSetupNum = 0;
    public float pHPValue, pHPMaxValue;
    Color White = new Color(255f, 255f, 255f, 0.3921569f);
    partial void StatusWinMethod()
    {
        pHPValueSet();
        if(sInit == true)
        {
            Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbb^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            StatusWinNum = 0;   
            pHPValueSet();
            /*~~~~~~~~~~~~~~~~~~*/
            SelectTabPrms = false;
            StatusWinBool = true;
            sInit = false;
            /*~~~~~~~~~~~~~~~~~~*/
        }
        if(StatusWinBool == true)
        {
            
            if(StatusWinNum == 0)//頭
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaa^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Helmet.GetComponent<Image>().color = Red;
                ChestPlate.GetComponent<Image>().color = White;
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    StatusWinNum = 1;
                }
            }
            else if(StatusWinNum == 1)//胸
            {
                Helmet.GetComponent<Image>().color = White;
                ChestPlate.GetComponent<Image>().color = Red;
                LeftHand.GetComponent<Image>().color = White;
                RightHand.GetComponent<Image>().color = White;
                Leggings.GetComponent<Image>().color = White;
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    StatusWinNum = 0;
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    StatusWinNum = 2;
                }
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    StatusWinNum = 3;
                }
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    StatusWinNum = 4;
                }
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    StatusWinBool = false;
                    StatusTab = false;
                    SelectTabPrms = true;
                }
            }
            else if(StatusWinNum == 2)//左腕
            {
                ChestPlate.GetComponent<Image>().color = White;
                LeftHand.GetComponent<Image>().color = Red;
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    StatusWinNum = 1;
                }
            }
            else if(StatusWinNum == 3)//右腕
            {
                ChestPlate.GetComponent<Image>().color = White;
                RightHand.GetComponent<Image>().color = Red;
                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    StatusWinNum = 1;
                }
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    ArmorSetupNum = 3;
                }
            }
            else if(StatusWinNum == 4)//ズボン
            {
                ChestPlate.GetComponent<Image>().color = White;
                Leggings.GetComponent<Image>().color = Red;
                Boots.GetComponent<Image>().color = White;
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    StatusWinNum = 1;
                }
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    StatusWinNum = 5;
                }
            }
            else if(StatusWinNum == 5)//靴
            {
                Leggings.GetComponent<Image>().color = White;
                Boots.GetComponent<Image>().color = Red;
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    StatusWinNum = 4;
                }
            }

            if(ArmorSetupNum == 3)
            {
                RightArmArmorSet();
            }


        }

    }

    //==============================================
    //      関数参照
    //==============================================
    partial void RightArmArmorSet();

    void pHPValueSet()
    {
            pHPMaxValue = PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMaxHP;
            pHPValue = PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetHP;
            pHPBer.maxValue = pHPMaxValue;
            pHPBer.value = pHPValue;
            Debug.Log(pHPMaxValue + " : " + pHPValue);
    }
}
