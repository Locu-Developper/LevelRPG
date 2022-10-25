using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Inventory
{
    partial void ImpItemSlotMethod()
    {
        if(ItemImpSlotPrms == true)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ImpSlotX--;
                if(ImpSlotX < 0)
                {
                    ImpSlotX = 0;
                    tmpItemImpSlotPrms = ItemImpSlotPrms;
                    ItemImpSlotPrms = false;
                    SelectTabPrms = true;
                    ItemTabFrame.SetActive(false);
                    ImpItemSlot[_ImpItemSlotMethod.nowImpSlotNum].GetComponent<Image>().color = new Color(255f, 255f , 255f, 0.3921569f);
                    return;
                }

            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                ImpSlotX++;
                if(ImpSlotX > 7)
                {
                    ImpSlotX = 7;
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                ImpSlotY--;
                if(ImpSlotY < 0)
                {
                    ImpSlotY = 0;
                    InventoryItemTab[1].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
                    ImpSlotAllClear();
                    ItemSlotNorORImpChangePrms = true;
                    ItemSlotPrms = false;
                    return;
                }

            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                ImpSlotY++;
                if(ImpSlotY > 5)
                {
                    ImpSlotY = 5;
                }
            }
            ImpSlotAllClear();
            _ImpItemSlotMethod.ItemImpSlotPosition(ImpSlotX,ImpSlotY);
            ImpItemSlot[_ImpItemSlotMethod.nowImpSlotNum].GetComponent<Image>().color = new Color(255f, 0 , 0, 0.7f);

        }

    }
}
