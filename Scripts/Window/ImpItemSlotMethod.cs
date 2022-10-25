using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpItemSlotMethod : MonoBehaviour
{

    public int nowImpSlotNum = 0;
    int ctrlNum;

    void Start()
    {
    }

    public void ItemImpSlotPosition(int x, int y)
    {
        if(x == 0)
        {
            ctrlNum = 0;
            if(y == 0)
            {
                nowImpSlotNum = 0;
            }
            if(y == 1)
            {
                nowImpSlotNum = 8;
            }
            if(y == 2)
            {
                nowImpSlotNum = 16;
            }
            if(y == 3)
            {
                nowImpSlotNum = 24;
            }
            if(y == 4)
            {
                nowImpSlotNum = 32;
            }
            if(y == 5)
            {
                nowImpSlotNum = 40;
            }
        }
        if(x == 1)
        {
            ctrlNum = 1;
            if(y == 0)
            {
                nowImpSlotNum = 1;
            }
            if(y == 1)
            {
                nowImpSlotNum = 9;
            }
            if(y == 2)
            {
                nowImpSlotNum = 17;
            }
            if(y == 3)
            {
                nowImpSlotNum = 25;
            }
            if(y == 4)
            {
                nowImpSlotNum = 33;
            }
            if(y == 5)
            {
                nowImpSlotNum = 41;
            }

        }
        if(x == 2)
        {
            ctrlNum = 2;
            if(y == 0)
            {
                nowImpSlotNum = 2;
            }
            if(y == 1)
            {
                nowImpSlotNum = 10;
            }
            if(y == 2)
            {
                nowImpSlotNum = 18;
            }
            if(y == 3)
            {
                nowImpSlotNum = 26;
            }
            if(y == 4)
            {
                nowImpSlotNum = 34;
            }
            if(y == 5)
            {
                nowImpSlotNum = 42;
            }

        }
        if(x == 3)
        {
            ctrlNum = 3;
            if(y == 0)
            {
                nowImpSlotNum = 3;
            }
            if(y == 1)
            {
                nowImpSlotNum = 11;
            }
            if(y == 2)
            {
                nowImpSlotNum = 19;
            }
            if(y == 3)
            {
                nowImpSlotNum = 27;
            }
            if(y == 4)
            {
                nowImpSlotNum = 35;
            }
            if(y == 5)
            {
                nowImpSlotNum = 43;
            }
        }
        if(x == 4)
        {
            ctrlNum = 4;
            if(y == 0)
            {
                nowImpSlotNum = 4;
            }
            if(y == 1)
            {
                nowImpSlotNum = 12;
            }
            if(y == 2)
            {
                nowImpSlotNum = 20;
            }
            if(y == 3)
            {
                nowImpSlotNum = 28;
            }
            if(y == 4)
            {
                nowImpSlotNum = 36;
            }
            if(y == 5)
            {
                nowImpSlotNum = 44;
            }
        }
        if(x == 5)
        {
            ctrlNum = 5;
            if(y == 0)
            {
                nowImpSlotNum = 5;
            }
            if(y == 1)
            {
                nowImpSlotNum = 13;
            }
            if(y == 2)
            {
                nowImpSlotNum = 21;
            }
            if(y == 3)
            {
                nowImpSlotNum = 29;
            }
            if(y == 4)
            {
                nowImpSlotNum = 37;
            }
            if(y == 5)
            {
                nowImpSlotNum = 45;
            }
        }
        if(x == 6)
        {
            ctrlNum = 6;
            if(y == 0)
            {
                nowImpSlotNum = 6;
            }
            if(y == 1)
            {
                nowImpSlotNum = 14;
            }
            if(y == 2)
            {
                nowImpSlotNum = 22;
            }
            if(y == 3)
            {
                nowImpSlotNum = 30;
            }
            if(y == 4)
            {
                nowImpSlotNum = 38;
            }
            if(y == 5)
            {
                nowImpSlotNum = 46;
            }
        }
        if(x == 7)
        {
            ctrlNum = 7;
            if(y == 0)
            {
                nowImpSlotNum = 7;
            }
            if(y == 1)
            {
                nowImpSlotNum = 15;
            }
            if(y == 2)
            {
                nowImpSlotNum = 23;
            }
            if(y == 3)
            {
                nowImpSlotNum = 31;
            }
            if(y == 4)
            {
                nowImpSlotNum = 39;
            }
            if(y == 5)
            {
                nowImpSlotNum = 47;
            }
        }

    }

}
