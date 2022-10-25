using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //プレイヤーステータス参照
    public GameObject psManager;
    PlayerStatusManager PSManager;

    //通常変数宣言
    private int LevelNow;

    //アイテムリスト生成
    public List<string> WeaponName = new List<string>();
    public List<int> WeaponNum = new List<int>(), WeaponPrice = new List<int>();
    public List<Sprite> WeaponImg = new List<Sprite>();
    void Start()
    {
        PSManager = psManager.GetComponent<PlayerStatusManager>();
        

    }

    void Update()
    {
        LevelMonitoring();
    }

    void LevelMonitoring()
    {
        LevelNow = PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetLevel;
        LevelEveryWeaponList();

        Debug.Log(LevelNow);
    }

    //レベル毎武器リスト
    void LevelEveryWeaponList()
    {
/*        if(LevelNow == 30)
        {
            
*/ 
            WeaponName.Add("木刀");
            WeaponNum.Add(1);
            WeaponPrice.Add(1000);
            WeaponName.Add("bbbbbbbbbbbbbbbbbbb");
            WeaponNum.Add(1);
            WeaponPrice.Add(400);
            WeaponName.Add("ccccccccccccccccccc");
            WeaponNum.Add(1);
            WeaponPrice.Add(1000);
            WeaponName.Add("ddddddddddddddddddd");
            WeaponNum.Add(1);
            WeaponPrice.Add(1);
            WeaponName.Add("eeeeeeeeeeeeeeeeeee");
            WeaponNum.Add(1);
            WeaponPrice.Add(30);
/*        }
*/    }
}
