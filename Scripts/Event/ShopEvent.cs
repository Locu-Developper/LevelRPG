using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InputLimiterKey;
using System;

public class ShopEvent : MonoBehaviour
{
    //スクリプト参照
    public GameObject WindowEveryParent, CharaDlgWin, ShopItemWin, LevelMonitoring, pObj, plStatus;
    CharacterDialogue CharaDlg;
    Level levelMonitoring;
    PlayerMove pMove;
    ItemListManager itemLiManager;

    // Prefab 参照
    public GameObject awsItem;

    //ルート分岐
    private int weaponShopDlgNum = 0;
    [SerializeField]
    private bool awsShop = false;
    private bool inRootJudge = false, awsShopIn = false;

    //制御宣言
    private float waitTimer;
    private int ForTimer, ItemNum, ItemListCount, ItemListCountDelFront, ItemListCountDelRear, SelectItemNum;
    private bool DownEndJudgeItemList, UpEndJudgeItemList;

    //アイテムリスト設定
    public GameObject ParentItemList, ChildrenItemList;
    public List<GameObject> WeaponList = new List<GameObject>();
    public int idNum = 0;


    public bool GetAwsShop
    {
        get => awsShop;
        set => awsShop = value;
    }

    //名前・セリフ参照
    private string[] CharaName =
    {
        "武器屋の店主"
    };

    //テキスト参照
    public GameObject CharaDlgFrame, CharaNameDlgFrame;
    TextMeshProUGUI CharaDlgFrame_t, CharaNameDlgFrame_t;

    //アイテムリスト 制御変数
    private Color ItemSelected = new Color(255f, 0, 0, 0.5f), ItemNotSelected = new Color(255f, 255f, 255f, 0.3921f);
    public GameObject WeaponItemConfirmWin, WaponItemName, WeaponItemPrice, WeaponItemImg;
    TextMeshProUGUI WeaponItemName_t, WeaponItemPrice_t; 
    Image WeaponItemImg_i;

    //選択肢
    public GameObject ChoiceWin, YesBtn, NoBtn;

    //カラー
    Color Red = new Color(255f, 0, 0), Black = new Color(0, 0, 0, 0.6901961f);

    //金
    public GameObject money_o, InventryMoney_o;
    TextMeshProUGUI money_t, InventryMoney_t;
    public int Money;
    

    // Start is called before the first frame update
    void Start()
    {
        CharaDlgWin.SetActive(false);
        CharaDlg = GetComponent<CharacterDialogue>();
        CharaDlgFrame_t = CharaDlgFrame.GetComponent<TextMeshProUGUI>();
        CharaNameDlgFrame_t = CharaNameDlgFrame.GetComponent<TextMeshProUGUI>();
        levelMonitoring = LevelMonitoring.GetComponent<Level>();
        pMove = pObj.GetComponent<PlayerMove>();
        WeaponItemName_t = WaponItemName.GetComponent<TextMeshProUGUI>();
        WeaponItemPrice_t = WeaponItemPrice.GetComponent<TextMeshProUGUI>();
        WeaponItemImg_i = WeaponItemImg.GetComponent<Image>();
        itemLiManager = plStatus.GetComponent<ItemListManager>();
        WeaponItemConfirmWin.SetActive(false);
        ChoiceWin.SetActive(false);
        YesBtn.GetComponent<Image>().color = Red;
        money_t = money_o.GetComponent<TextMeshProUGUI>();
        InventryMoney_t = InventryMoney_o.GetComponent<TextMeshProUGUI>();
        ForTimer = 0;
        ItemNum = 5;
        Money = 5000;
        MoneyReload(Money);
    }

    // Update is called once per frame
    void Update()
    {
        //武器屋　ルート
        if(awsShop == true)
        {
            AwsShopEvent();
        }
    }

    //武器屋イベント
    public void AwsShopEvent()
    {
        
        //Debug.Log(weaponShopDlgNum + " : inRootJudge = " + inRootJudge.ToString() + " : weaponShopDlgNum = " + weaponShopDlgNum);
        if(inRootJudge == false)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                CharaDlgWin.SetActive(true);
                inRootJudge = true;
            }
        }
        if(inRootJudge == true)
        {
            if(weaponShopDlgNum == 0)
            {
                weaponShopDlgNum = 1;
            }
            else if(weaponShopDlgNum == 1)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[0];
                CharaNameDlgFrame_t.text = CharaName[0];

                if(Input.GetKeyDown(KeyCode.Return))
                {
                    weaponShopDlgNum = 2;
                }
            }
            else if(weaponShopDlgNum == 2)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[1];
                waitTimer = Time.time;
                awsShopIn = true;
                Debug.Log(ForTimer);
                if(waitTimer >= 1.0f)
                {
                    //Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                    if(awsShopIn == true)
                    {
                        CharaDlgWin.SetActive(false);
                        ShopItemWin.SetActive(true);
                        if( ForTimer == ItemNum)
                        {
                            ItemListSelect();
                            if (Input.GetKeyDown(KeyCode.Return))//アイテム選択
                            {
                                double result = Math.Sign(Money - levelMonitoring.WeaponPrice[SelectItemNum]);
                                if(result == -1)
                                {
                                    CharaDlgWin.SetActive(true);
                                    WeaponItemConfirmWin.SetActive(false);
                                    weaponShopDlgNum = 7;
                                }
                                else
                                {
                                    SelectItemNum = ItemListCount;
                                    CharaDlgWin.SetActive(true);
                                    WeaponItemConfirmWin.SetActive(true);
                                    WeaponItemImg_i.sprite = levelMonitoring.WeaponImg[SelectItemNum];
                                    WeaponItemName_t.text = levelMonitoring.WeaponName[SelectItemNum];
                                    WeaponItemPrice_t.text = levelMonitoring.WeaponPrice[SelectItemNum].ToString();
                                    weaponShopDlgNum = 3;
                                }
                            }
                            if(Input.GetKeyDown(KeyCode.Escape))//店を出る
                            {
                                CharaDlgWin.SetActive(true);
                                WeaponItemConfirmWin.SetActive(false);
                                weaponShopDlgNum = 6;
                            }
                        }
                        else if( ForTimer == 0 ){
                            GameObject ItemListEvery = Instantiate(awsItem, new Vector3(400.0f, 473.2f, 0f), Quaternion.identity, ParentItemList.transform);
                            ItemListEvery.name = ForTimer.ToString();
                            ItemListEvery.GetComponent<Image>().color = new Color(255f, 0f, 0f);
                            ItemListEvery.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelMonitoring.WeaponName[ForTimer];
                            ItemListEvery.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = levelMonitoring.WeaponNum[ForTimer].ToString();
                            ItemListEvery.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = levelMonitoring.WeaponPrice[ForTimer].ToString();
                            WeaponList.Add(ItemListEvery);
                            ForTimer++;
                            //DownCount++;
                        }
                        else{
                            GameObject ItemListEvery = Instantiate(awsItem, new Vector3(400.0f, 473.2f - (46.12f * (ForTimer )), 0f), Quaternion.identity, ParentItemList.transform);
                            ItemListEvery.name = ForTimer.ToString();
                            ItemListEvery.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelMonitoring.WeaponName[ForTimer];
                            ItemListEvery.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = levelMonitoring.WeaponNum[ForTimer].ToString();
                            ItemListEvery.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = levelMonitoring.WeaponPrice[ForTimer].ToString();
                            WeaponList.Add(ItemListEvery);
                            ForTimer++;
                        }
                    }

                }
            }
            else if(weaponShopDlgNum == 3)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[2];
                waitTimer = 0f;
                waitTimer = Time.time;
                if(waitTimer >= 1.0f)
                {
                    ChoiceWin.SetActive(true);
                    YesORNoSelected();
                    if(YesBtn.GetComponent<Image>().color == Red)
                    {
                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            GetItemListAdd(idNum, levelMonitoring.WeaponName[SelectItemNum].ToString(), levelMonitoring.WeaponImg[SelectItemNum], levelMonitoring.WeaponNum[SelectItemNum], 0);
                            idNum++;
                            Money = Money - levelMonitoring.WeaponPrice[SelectItemNum];
                            MoneyReload(Money);
                            ChoiceWin.SetActive(false);
                            weaponShopDlgNum = 4;
                        }

                    }
                    if(NoBtn.GetComponent<Image>().color == Red)
                    {
                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            ChoiceWin.SetActive(false);
                            weaponShopDlgNum = 2;
                        }

                    }
                }

            }
            else if(weaponShopDlgNum == 4)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[3];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    weaponShopDlgNum = 5;
                }
            }
            else if(weaponShopDlgNum == 5)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[4];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    weaponShopDlgNum = 2;
                }
            }
            else if(weaponShopDlgNum == 6)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[5];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    ShopItemWin.SetActive(false);
                    weaponShopDlgNum = 0;
                    inRootJudge = false;
                    awsShop = false;
                    CharaDlgWin.SetActive(false);
                    pMove.enabled = true;
                }
            }
            else if(weaponShopDlgNum == 7)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[6];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    weaponShopDlgNum = 8;
                }
            }
            else if(weaponShopDlgNum == 8)
            {
                CharaDlgFrame_t.text = CharaDlg.weaponDialog[7];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    ShopItemWin.SetActive(false);
                    weaponShopDlgNum = 0;
                    inRootJudge = false;
                    awsShop = false;
                    CharaDlgWin.SetActive(false);
                    pMove.enabled = true;
                }
            }
        }
    }

    void ItemListSelect()
    {
        pMove.enabled = false;
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if( ItemListCount >= 0)
            {
                DownEndJudgeItemList = true;
                ItemListCount++;
                ItemListCountDelFront = ItemListCount - 1;
            }
            if( ItemListCount >= ItemNum - 1)
            {
                DownEndJudgeItemList = false;
                ItemListCount = ItemNum - 1;
                ItemListCountDelFront = ItemListCount - 1;
            }
            if( DownEndJudgeItemList == true)
            {
                ItemListCountDelRear = ItemListCount + 1;
                WeaponList[ItemListCountDelRear].GetComponent<Image>().color = ItemNotSelected;
            }
            WeaponList[ItemListCountDelFront].GetComponent<Image>().color = ItemNotSelected;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if( ItemListCount >= 0 )
            {
                UpEndJudgeItemList = true;
                ItemListCount--;
                ItemListCountDelRear = ItemListCount + 1;
                if( ItemListCount == -1)
                {
                    UpEndJudgeItemList = false;
                    ItemListCount = 0;
                    ItemListCountDelRear = 1;

                }

            }
            if( UpEndJudgeItemList == true)
            {
                ItemListCountDelFront = ItemListCount + 1;
                WeaponList[ItemListCountDelFront].GetComponent<Image>().color = ItemNotSelected;
            }
            WeaponList[ItemListCountDelRear].GetComponent<Image>().color = ItemNotSelected;
        }

        WeaponList[ItemListCount].GetComponent<Image>().color = ItemSelected;
        Debug.Log(ItemListCount);
    }

    void YesORNoSelected()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            YesBtn.GetComponent<Image>().color = Red;
            NoBtn.GetComponent<Image>().color = Black;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            YesBtn.GetComponent<Image>().color = Black;
            NoBtn.GetComponent<Image>().color = Red;
        }
    }

    void GetItemListAdd(int id, string name, Sprite img, int num, int type)
    {

        itemLiManager.ItemId.Add(id);
        itemLiManager.ItemImg.Add(img);
        itemLiManager.ItemName.Add(name);
        itemLiManager.ItemQty.Add(num);
        itemLiManager.ItemType.Add(type);
    }

    public void MoneyReload(int money)
    {
        money_t.text = money.ToString();
        InventryMoney_t.text = money.ToString();
    }
}
