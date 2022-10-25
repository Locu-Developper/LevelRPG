using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BattleManager
{
    partial void MagicMethod()
    {
        if(MagicInit == true)
        {
            CommandRoot.SetActive(false);
            CommandMgc.SetActive(true);
            Magic = true;
            MagicInit = false;
        }
        else if(Magic == true)
        {
            if(SelectNumMgc == 0)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Magic = false;
                    Root = true;
                    CommandRoot.SetActive(true);
                    CommandMgc.SetActive(false);

                }
            }
        }

    }
}
