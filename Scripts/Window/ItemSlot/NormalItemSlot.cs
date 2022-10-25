using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Inventory
{
    partial void NorItemSlotMethod()
    {
        if(ItemSlotPrms == true)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SlotX--;
                if(SlotX < 0)
                {
                    SlotX = 0;
                    tmpItemSlotPrms = ItemSlotPrms;
                    ItemSlotPrms = false;
                    SelectTabPrms = true;
                    ItemTabFrame.SetActive(false);
                    ItemSlot[_ItemSlotMethod.nowSlotNum].GetComponent<Image>().color = new Color(255f, 255f , 255f, 0.3921569f);
                    return;
                }

            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                SlotX++;
                if(SlotX > 7)
                {
                    SlotX = 7;
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                SlotY--;
                if(SlotY < 0)
                {
                    SlotY = 0;
                    InventoryItemTab[0].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
                    NormalSlotAllClear();
                    ItemSlotNorORImpChangePrms = true;
                    ItemSlotPrms = false;
                    return;
                }

            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                SlotY++;
                if(SlotY > 5)
                {
                    SlotY = 5;
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
            NormalSlotAllClear();
            _ItemSlotMethod.ItemSlotPosition(SlotX,SlotY);
            ItemSlot[_ItemSlotMethod.nowSlotNum].GetComponent<Image>().color = new Color(255f, 0 , 0, 0.7f);

        }

    }
}
