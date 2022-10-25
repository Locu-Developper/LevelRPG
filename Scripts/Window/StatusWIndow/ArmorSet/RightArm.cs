using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Inventory
{
    int RightArmArmorSetNum = 0;
    partial void RightArmArmorSet()
    {
        
        RightArmSet();
    }

    void RightArmSet()
    {
        if(RightArmArmorSetNum == 0)
        {
            ArmorItemPanel.SetActive(true);
            StatusPanel.SetActive(false);
            RightArmArmorSetNum = 1;
            StatusWinNum = 999;
        }
        if(RightArmArmorSetNum == 1)
        {
            Debug.Log("-===========================================================-");
            StatusItemSlot();
        }

    }

    partial void StatusItemSlot();
}
