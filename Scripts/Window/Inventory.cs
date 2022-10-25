using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class Inventory : MonoBehaviour
{
    GameObject Inventory_o;

    public GameObject[] TabList, TabSelectedJudge;
    public GameObject pMove, sEvent;
    PlayerMove _pMove;
    ShopEvent _sEvent;
    //StatusWindow _StatusWin;

    Color sky = new Color(0.1411765f, 0.9372549f, 1f, 0.7215686f), black = new Color(0, 0, 0, 0.7215686f);
    Vector2 NoSelectTabVec2 = new Vector2(205.3f, 140.8f), SelectedTabVec2 = new Vector2();
    public int selectedTabNum, selectedTabNumRear, selectedTabNumFront;
    public bool SelectTabPrms, simStartprms = true, DownLimitter, UpLimitter;

    //タブ別
    public GameObject   ItemPanel, StatusPanel, SettingsPanel, ArmorItemPanel,              //タブ別パネル
                        ItemTabFrame, StatusTabFrame, SettingsTabFrame,     //タブフレーム
                        NorItemCounter_o, ImpItemCounter_o,                 //アイテムタブ　アイテム数
                        ItemNormalPanel, ItemImpPanel,
                        ItemUseYes, ItemUseNo, ItemUseQuestion,
                        ShopEventFrame,                                     //ショップイベントマス
                        PStatusManager;                                    
    public GameObject[] InventoryItemTab;
    TextMeshProUGUI NorItemCounter_t, ImpItemCounter_t;                     //アイテムカウンター
    ItemSlotMethod _ItemSlotMethod;
    ImpItemSlotMethod _ImpItemSlotMethod;
    ArmorItemSlot _ArmorItemSlot;
    PlayerStatusManager PSManager;
    public bool ItemSlotPrms, ItemSlotNorORImpChangePrms, ItemImpSlotPrms;
    public bool tmpItemSlotPrms, tmpItemImpSlotPrms;
    public bool AlwaysUpdateAva;
    public int SlotX, SlotY, ImpSlotX, ImpSlotY;

    public GameObject ParentItemSlot, ParentImpItemSlot, ParentArmorItemSlot;
    public GameObject[] ItemSlot, ImpItemSlot, ArmorItemSlot;

    Color Red = new Color(255f, 0, 0, 0.3921569f);

    //スクリプト参照
    public GameObject plStatus;
    ItemListManager itemLiManager;


    //-----------------------------------------------------------
    //      ステータスタブ
    //-----------------------------------------------------------
    public bool StatusTab;

//------------------------------------------------------- スタート
    void Start()
    {
        simStart();
    }

//-----------------------------------------------------スタート関数
    void simStart()
    {
        Inventory_o = this.gameObject;
        selectedTabNum = 0;
        SelectTabPrms = true;
        _pMove = pMove.GetComponent<PlayerMove>();
        _ItemSlotMethod = Inventory_o.GetComponent<ItemSlotMethod>();
        _ImpItemSlotMethod = Inventory_o.GetComponent<ImpItemSlotMethod>();
        PSManager = PStatusManager.GetComponent<PlayerStatusManager>();
        _sEvent = sEvent.GetComponent<ShopEvent>();
        itemLiManager = plStatus.GetComponent<ItemListManager>();
        _pMove.enabled = false;
        ItemSlotPrms = false;
        ItemSlotNorORImpChangePrms = false;
        _sEvent.GetAwsShop = false;
        AlwaysUpdateAva = true;
        GetAllChildObject();
        ShopEventInvalid();
        NorItemCounter_t = NorItemCounter_o.GetComponent<TextMeshProUGUI>();
        ImpItemCounter_t = ImpItemCounter_o.GetComponent<TextMeshProUGUI>();
        _ArmorItemSlot = GetComponent<ArmorItemSlot>();
        PSManager = PStatusManager.GetComponent<PlayerStatusManager>();
    }

//---------------------------------------------------------インベントリ
    void Update()
    {
        SelectedTab();
    }

    void SelectedTab()
    {
        ItemReload();
        if(simStartprms == true)
        {
            simStart();
            simStartprms = false;
        }
        if(SelectTabPrms == true)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(selectedTabNum >= 0)
                {
                    selectedTabNum++;
                    if(selectedTabNum > 2)
                    {
                        selectedTabNum = 2;
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(selectedTabNum >= 0)
                {
                    selectedTabNum--;

                    if(selectedTabNum < 0)
                    {
                        selectedTabNum = 0;
                    }
                }
                
            }
            if(selectedTabNum == 0)//アイテム
            {
                TabSelectedJudge[selectedTabNum].SetActive(true);
                TabSelectedJudge[selectedTabNum + 1].SetActive(false);
                ItemPanel.SetActive(true);
                StatusPanel.SetActive(false);
                ItemTabFrame.SetActive(false);
                StatusTabFrame.SetActive(true);
                if(Input.GetKeyUp(KeyCode.RightArrow))
                {
                    SelectTabPrms = false;
                    ItemSlotPrms = true;
                    ItemImpSlotPrms = false;
                    ItemTabFrame.SetActive(true);
                    ItemNormalPanel.SetActive(true);
                    ItemImpPanel.SetActive(false);
                    NormalSlotAllClear();
                    ImpSlotAllClear();
                }
            }
            if(selectedTabNum == 1)//ステータス
            {
                TabSelectedJudge[selectedTabNum - 1].SetActive(false);
                TabSelectedJudge[selectedTabNum].SetActive(true);
                TabSelectedJudge[selectedTabNum + 1].SetActive(false);
                ItemPanel.SetActive(false);
                StatusPanel.SetActive(true);
                SettingsPanel.SetActive(false);
                ItemTabFrame.SetActive(true);
                StatusTabFrame.SetActive(false);
                SettingsTabFrame.SetActive(true);
                Helmet.GetComponent<Image>().color = White;
                ChestPlate.GetComponent<Image>().color = White;
                RightHand.GetComponent<Image>().color = White;
                LeftHand.GetComponent<Image>().color = White;
                Leggings.GetComponent<Image>().color = White;
                Boots.GetComponent<Image>().color = White;
                pHPValueSet();
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    StatusTab = true;
                    sInit = true;
                }
            }
            if(selectedTabNum == 2)//設定
            { 
                TabSelectedJudge[selectedTabNum - 1].SetActive(false);
                TabSelectedJudge[selectedTabNum].SetActive(true);
                StatusPanel.SetActive(false);
                SettingsPanel.SetActive(true);
                StatusTabFrame.SetActive(true);
                SettingsTabFrame.SetActive(false);
            }

        }
        //-------------------------------------------------------- 
        //      ノーマルアイテムスロット
        //-------------------------------------------------------- 
        NorItemSlotMethod();
        if(ItemSlotNorORImpChangePrms == true)
        {
            NorORImpTabChange();
        }

        //-----------------------------------------------------------------
        //      重要アイテムスロット
        //-----------------------------------------------------------------
        ImpItemSlotMethod();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Inventory_o.SetActive(false);
            _pMove.enabled = true;
            simStartprms = true;
            ShopEventFrame.SetActive(true);
            //AlwaysUpdateAva = false;
        }

        //----------------------------------------------------------------------
        //      ステータスタブ
        //----------------------------------------------------------------------
        if(StatusTab == true)
        {
            StatusWinMethod();
        }

    }

    //----------------------------------------------------------------------------------
    //      関数宣言
    //----------------------------------------------------------------------------------

    partial void StatusWinMethod();
    partial void NorItemSlotMethod();
    partial void ImpItemSlotMethod();



    private void GetAllChildObject()
    {
        ItemSlot = new GameObject[ParentItemSlot.transform.childCount];
        ImpItemSlot = new GameObject[ParentImpItemSlot.transform.childCount];
        ArmorItemSlot = new GameObject[ParentArmorItemSlot.transform.childCount];

        for (int i = 0; i < ParentItemSlot.transform.childCount; i++)
        {
            ItemSlot[i] = ParentItemSlot.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < ParentImpItemSlot.transform.childCount; i++)
        {
            ImpItemSlot[i] = ParentImpItemSlot.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < ParentArmorItemSlot.transform.childCount; i++)
        {
            ArmorItemSlot[i] = ParentArmorItemSlot.transform.GetChild(i).gameObject;
        }

    }

    void ItemReload()
    {
        if(itemLiManager.ItemId.Count == 0)
        {
            return;
        }
        else
        {
            for(int i = 0; i < itemLiManager.ItemId.Count; i++)
            {
                ItemSlot[i].GetComponent<Image>().sprite = itemLiManager.ItemImg[i];
            }
        }
    }

    void NorORImpTabChange()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ItemSlotPrms = false;
            InventoryItemTab[0].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
            InventoryItemTab[1].GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.3921569f);
            ItemNormalPanel.SetActive(true);
            ItemImpPanel.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ItemImpSlotPrms = false;
            InventoryItemTab[0].GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.3921569f);
            InventoryItemTab[1].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
            ItemNormalPanel.SetActive(false);
            ItemImpPanel.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (InventoryItemTab[0].GetComponent<Image>().color == Red)
            {
                ItemSlotPrms = true;
                ItemSlot[_ItemSlotMethod.nowSlotNum].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
                Debug.Log("Nor");
            }
            else if (InventoryItemTab[1].GetComponent<Image>().color == Red)
            {
                ItemImpSlotPrms = true;
                ImpItemSlot[_ImpItemSlotMethod.nowImpSlotNum].GetComponent<Image>().color = new Color(255f, 0, 0, 0.3921569f);
                Debug.Log("Imp");
            }

            ItemSlotNorORImpChangePrms = false;
            InventoryItemTab[0].GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.3921569f);
            InventoryItemTab[1].GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.3921569f);

            return;
        }

    }

    void ShopEventInvalid()
    {
        ShopEventFrame.SetActive(false);
        //this.GetComponent<InventoryAlwaysUpdate>().AlwaysUpdate();
    }

    void NormalSlotAllClear()
    {
        for(int i = 0; i < 48; i++)
        {
            ItemSlot[i].GetComponent<Image>().color = new Color(255f, 255f , 255f, 0.3921569f);
        }

    }
    void ImpSlotAllClear()
    {
        for(int i = 0; i < 48; i++)
        {
            ImpItemSlot[i].GetComponent<Image>().color = new Color(255f, 255f , 255f, 0.3921569f);
        }

    }

    void ItemUseMethod()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ItemUseYes.GetComponent<Image>().color = Red;
        }
    }

}
