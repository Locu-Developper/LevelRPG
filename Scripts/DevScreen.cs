using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevScreen : MonoBehaviour
{
    public GameObject devScreen, PSManager, levelG, hpG, mpG, atkG, matG, defG, ERNumG, pMove;
    Text level, hp, mp, atk, mat, def, ERanNum;
    private bool f12 = false;
    // Start is called before the first frame update
    void Start()
    {
        devScreen.SetActive(false);

        level = levelG.GetComponent<Text>();
        hp = hpG.GetComponent<Text>();
        mp = mpG.GetComponent<Text>();
        atk = atkG.GetComponent<Text>();
        mat = matG.GetComponent<Text>();
        def = defG.GetComponent<Text>();
        ERanNum = ERNumG.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            if(f12 == false)
            {
                devScreen.SetActive(true);
                f12 = true;
            }
            else if(f12 == true)
            {
                devScreen.SetActive(false);
                f12 = false;
            }
        }

        level.text      =   "lv  " + PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetLevel.ToString();
        hp.text         =   "HP  " + PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetHP.ToString();
        mp.text         =   "MP  " + PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMP.ToString();
        atk.text        =   "ATK " + PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetAtk.ToString();
        mat.text        =   "MAT " + PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMat.ToString();
        def.text        =   "DEF " + PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetDef.ToString();
        ERanNum.text    =   "Enemy RDM Num [ " + pMove.GetComponent<PlayerMove>().Getrnd.ToString() + " ]";
    }
}
