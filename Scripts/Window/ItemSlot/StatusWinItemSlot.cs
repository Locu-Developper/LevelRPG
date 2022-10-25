using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Inventory
{

    int ArmorSlotX, ArmorSlotY;


    partial void StatusItemSlot()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ArmorSlotX--;
                if(ArmorSlotX < 0)
                {
                    ArmorSlotX = 0;
                    //tmpItemSlotPrms = ItemSlotPrms;
                    //ItemSlotPrms = false;
                    //SelectTabPrms = true;
                    //ItemTabFrame.SetActive(false);
                    //ArmorItemSlot[_ArmorItemSlot.nowArmorSlotNum].GetComponent<Image>().color = new Color(255f, 255f , 255f, 0.3921569f);
                    //return;
                }

            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                ArmorSlotX++;
                if(ArmorSlotX > 7)
                {
                    ArmorSlotX = 7;
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                ArmorSlotY--;
                if(ArmorSlotY < 0)
                {
                    ArmorSlotY = 0;
                    //InventoryItemTab[0].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
                    //NormalSlotAllClear();
                    //ItemSlotNorORImpChangePrms = true;
                    //ItemSlotPrms = false;
                    //return;
                }

            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                ArmorSlotY++;
                if(ArmorSlotY > 5)
                {
                    ArmorSlotY = 5;
                }
            }
            if(Input.GetKeyDown(KeyCode.Return))
            {
                ItemUseYes.SetActive(true);
                ItemUseNo.SetActive(true);
                ItemUseNo.GetComponent<Image>().color = Red;
                ItemUseQuestion.SetActive(true);
                ItemUseMethod();
                return;
            }
            //NormalSlotAllClear();
            _ArmorItemSlot.ItemArmorSlotPosition(ArmorSlotX,ArmorSlotY);
            ArmorItemSlot[_ArmorItemSlot.nowArmorSlotNum].GetComponent<Image>().color = new Color(255f, 0 , 0, 0.7f);
            Debug.Log(ArmorSlotX + " : " + ArmorSlotY);
    }
}
