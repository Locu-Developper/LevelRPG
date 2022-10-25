using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotMethod : MonoBehaviour
{

    public int SlotPositionX, SlotPositionY;

    public int nowSlotNum = 0;
    int ctrlNum;

    void Start()
    {
    }

    public void ItemSlotPosition(int x, int y)
    {
        if(x == 0)
        {
            ctrlNum = 0;
            if(y == 0)
            {
                nowSlotNum = 0;
            }
            if(y == 1)
            {
                nowSlotNum = 8;
            }
            if(y == 2)
            {
                nowSlotNum = 16;
            }
            if(y == 3)
            {
                nowSlotNum = 24;
            }
            if(y == 4)
            {
                nowSlotNum = 32;
            }
            if(y == 5)
            {
                nowSlotNum = 40;
            }
        }
        if(x == 1)
        {
            ctrlNum = 1;
            if(y == 0)
            {
                nowSlotNum = 1;
            }
            if(y == 1)
            {
                nowSlotNum = 9;
            }
            if(y == 2)
            {
                nowSlotNum = 17;
            }
            if(y == 3)
            {
                nowSlotNum = 25;
            }
            if(y == 4)
            {
                nowSlotNum = 33;
            }
            if(y == 5)
            {
                nowSlotNum = 41;
            }

        }
        if(x == 2)
        {
            ctrlNum = 2;
            if(y == 0)
            {
                nowSlotNum = 2;
            }
            if(y == 1)
            {
                nowSlotNum = 10;
            }
            if(y == 2)
            {
                nowSlotNum = 18;
            }
            if(y == 3)
            {
                nowSlotNum = 26;
            }
            if(y == 4)
            {
                nowSlotNum = 34;
            }
            if(y == 5)
            {
                nowSlotNum = 42;
            }

        }
        if(x == 3)
        {
            ctrlNum = 3;
            if(y == 0)
            {
                nowSlotNum = 3;
            }
            if(y == 1)
            {
                nowSlotNum = 11;
            }
            if(y == 2)
            {
                nowSlotNum = 19;
            }
            if(y == 3)
            {
                nowSlotNum = 27;
            }
            if(y == 4)
            {
                nowSlotNum = 35;
            }
            if(y == 5)
            {
                nowSlotNum = 43;
            }
        }
        if(x == 4)
        {
            ctrlNum = 4;
            if(y == 0)
            {
                nowSlotNum = 4;
            }
            if(y == 1)
            {
                nowSlotNum = 12;
            }
            if(y == 2)
            {
                nowSlotNum = 20;
            }
            if(y == 3)
            {
                nowSlotNum = 28;
            }
            if(y == 4)
            {
                nowSlotNum = 36;
            }
            if(y == 5)
            {
                nowSlotNum = 44;
            }
        }
        if(x == 5)
        {
            ctrlNum = 5;
            if(y == 0)
            {
                nowSlotNum = 5;
            }
            if(y == 1)
            {
                nowSlotNum = 13;
            }
            if(y == 2)
            {
                nowSlotNum = 21;
            }
            if(y == 3)
            {
                nowSlotNum = 29;
            }
            if(y == 4)
            {
                nowSlotNum = 37;
            }
            if(y == 5)
            {
                nowSlotNum = 45;
            }
        }
        if(x == 6)
        {
            ctrlNum = 6;
            if(y == 0)
            {
                nowSlotNum = 6;
            }
            if(y == 1)
            {
                nowSlotNum = 14;
            }
            if(y == 2)
            {
                nowSlotNum = 22;
            }
            if(y == 3)
            {
                nowSlotNum = 30;
            }
            if(y == 4)
            {
                nowSlotNum = 38;
            }
            if(y == 5)
            {
                nowSlotNum = 46;
            }
        }
        if(x == 7)
        {
            ctrlNum = 7;
            if(y == 0)
            {
                nowSlotNum = 7;
            }
            if(y == 1)
            {
                nowSlotNum = 15;
            }
            if(y == 2)
            {
                nowSlotNum = 23;
            }
            if(y == 3)
            {
                nowSlotNum = 31;
            }
            if(y == 4)
            {
                nowSlotNum = 39;
            }
            if(y == 5)
            {
                nowSlotNum = 47;
            }
        }

    }

}
