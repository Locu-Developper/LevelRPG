using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItemSlot : MonoBehaviour
{

    public int nowArmorSlotNum = 0;
    int ctrlNum;

    void Start()
    {
    }

    public void ItemArmorSlotPosition(int x, int y)
    {
        if(x == 0)
        {
            ctrlNum = 0;
            if(y == 0)
            {
                nowArmorSlotNum = 0;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 8;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 16;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 24;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 32;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 40;
            }
        }
        if(x == 1)
        {
            ctrlNum = 1;
            if(y == 0)
            {
                nowArmorSlotNum = 1;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 9;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 17;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 25;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 33;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 41;
            }

        }
        if(x == 2)
        {
            ctrlNum = 2;
            if(y == 0)
            {
                nowArmorSlotNum = 2;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 10;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 18;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 26;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 34;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 42;
            }

        }
        if(x == 3)
        {
            ctrlNum = 3;
            if(y == 0)
            {
                nowArmorSlotNum = 3;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 11;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 19;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 27;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 35;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 43;
            }
        }
        if(x == 4)
        {
            ctrlNum = 4;
            if(y == 0)
            {
                nowArmorSlotNum = 4;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 12;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 20;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 28;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 36;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 44;
            }
        }
        if(x == 5)
        {
            ctrlNum = 5;
            if(y == 0)
            {
                nowArmorSlotNum = 5;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 13;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 21;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 29;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 37;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 45;
            }
        }
        if(x == 6)
        {
            ctrlNum = 6;
            if(y == 0)
            {
                nowArmorSlotNum = 6;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 14;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 22;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 30;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 38;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 46;
            }
        }
        if(x == 7)
        {
            ctrlNum = 7;
            if(y == 0)
            {
                nowArmorSlotNum = 7;
            }
            if(y == 1)
            {
                nowArmorSlotNum = 15;
            }
            if(y == 2)
            {
                nowArmorSlotNum = 23;
            }
            if(y == 3)
            {
                nowArmorSlotNum = 31;
            }
            if(y == 4)
            {
                nowArmorSlotNum = 39;
            }
            if(y == 5)
            {
                nowArmorSlotNum = 47;
            }
        }

    }

}
