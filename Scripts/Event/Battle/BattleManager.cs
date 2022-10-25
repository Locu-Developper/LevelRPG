using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class BattleManager : MonoBehaviour
{

    //------------ゲームオブジェクト参照----------------
    public GameObject[] SelectedGO, SelectedAtk, EnemyNameO, EnemyImg;
    public GameObject Info, PStatusManager, MonsterBook;
    public GameObject BTLWin, BTLMgr, PlayerStatus, CommandRoot, CommandAtk, CommandMgc, CommandItem, CommandRunAway;
        //プレイヤーステータス表示関連
        public GameObject hpDrawGObject;
        //  ゲームオーバー関連
        public GameObject GameOverWindow;
        //プレイヤー オブジェクト
        public GameObject PlayerObject;
        //カメラ
        public GameObject subCamera;
    //------------コンポーネント変数指定--------------------
    private Animator EnemyAnim1, EnemyAnim2, EnemyAnim3;
    private Text information;
    private Image Enemy1_Img, Enemy2_Img, Enemy3_Img;
    private TextMeshProUGUI Enemy1, Enemy2, Enemy3, hpDrawText;
    private HyphenationJpn InfoTurnBack;
    private AttackAnimEnd AtkAnimEndEnemy1, AtkAnimEndEnemy2, AtkAnimEndEnemy3;
    private MonsterBookManager MBook;
    private PlayerStatusManager PSManager;

    //-------------変数宣言--------------------------------
    private int SelectNum = 0, SelectNumAtk = 0, SelectNumMgc = 0, SelectNumItem = 0, serifAtkNum = 0, AtkDamageRnd = 0;
    private bool StartInfo = true, AtkInit = false, Root = false, Atk = false, MagicInit = false, Magic = false, ItemInit = false, Item = false, RunAway = false;
    private float DamageRnd = 0f;

    [SerializeField]
    private int NowLevel;

    //------------モンスター関連変数--------------
    public List<string> EnemyName = new List<string>();

    private int MonsterNum = 9;
    private int EnemyAtkRandom = 0, EnemyAtkRndMinNum = 0, EnemyAtkRndMaxNum = 0;
    //Enemy Status
    public List<int> EATK = new List<int>(), EATKch = new List<int>(), EMAT = new List<int>(), EMATch = new List<int>(), EDEF = new List<int>();
    public List<float> EHP = new List<float>(), EmaxHP = new List<float>(), EMP = new List<float>(), EmaxMP = new List<float>();
    //Player Status
    public List<int> playerStatus = new List<int>();
    public List<float> playerStatusF = new List<float>();
    public List<float> playerExp = new List<float>();
    //--------------モンスターアニメーション----------------

    protected enum MonsterIndex
    {
        slime = 1,
        zombie = 2,
        skeleton = 3,
        wolf = 4,
        witch = 5,
        bard = 6,
        VenusFlytrap = 7,
        dragon = 8,
        fairy = 9
    }

    protected enum MonsterAnimChg
    {
        Idle = 0,
        Atk = 1
    }


    //------------プレイヤーステータス参照---------------
    public Slider pHPBar, Enemy1Bar, Enemy2Bar, Enemy3Bar;


    //------------セリフ関連の変数宣言------------


    //------------コマンド文字列宣言--------------
    private string[] CommandMenu = 
    {
        "敵に攻撃をする",
        "敵に魔法攻撃をする",
        "アイテムを使用します",
        "敵から逃げます",
    };
    
    public List<int> BattleEnemyRnd = new List<int>(), MonsterID = new List<int>();
    //-------------セリフ宣言----------------------
    private int AtkSerifSpeed;
    private bool AtkSerifJudgeSpeed, EDamageRndJudgeOne;
    private string[] Atkserif =
    {
        "0",
        "1",
        "2"
    };

    //-------------ステータス関連宣言--------------------
    private static int LvAtkNum, EnemyRndNum;
    private bool EnemyCalc = true, PlayerCalc = true;

    //-------------ディメンション設定--------------------
    /*
        <dimention>
            [0] ⇒ 町周辺
            [1] ⇒ 危険エリア
            [2] ⇒ 離島
    */
    private int dimention = 0;


    //--------------スクリプト リロード--------------------
    private bool ScriptReload = false;


//----------------------------------------------------------------------------------------------------
//      バトルマネージャープログラム 開始
//----------------------------------------------------------------------------------------------------

    void Start()
    {
        SimStart();

    }

    void SimStart()
    {
        subCamera.SetActive(true);

        information = Info.GetComponent<Text>();

        Enemy1 = EnemyNameO[0].GetComponent<TextMeshProUGUI>();
        Enemy2 = EnemyNameO[1].GetComponent<TextMeshProUGUI>();
        Enemy3 = EnemyNameO[2].GetComponent<TextMeshProUGUI>();

        Enemy1_Img = EnemyImg[0].GetComponent<Image>();
        Enemy2_Img = EnemyImg[1].GetComponent<Image>();
        Enemy3_Img = EnemyImg[2].GetComponent<Image>();

        AtkAnimEndEnemy1 = EnemyImg[0].GetComponent<AttackAnimEnd>();
        AtkAnimEndEnemy2 = EnemyImg[1].GetComponent<AttackAnimEnd>();
        AtkAnimEndEnemy3 = EnemyImg[2].GetComponent<AttackAnimEnd>();

        SelectedGO[0].SetActive(true);
        SelectedGO[1].SetActive(false);
        SelectedGO[2].SetActive(false);
        SelectedGO[3].SetActive(false);

        EnemyAnim1 = EnemyImg[0].GetComponent<Animator>();
        EnemyAnim2 = EnemyImg[1].GetComponent<Animator>();
        EnemyAnim3 = EnemyImg[2].GetComponent<Animator>();

        InfoTurnBack = Info.GetComponent<HyphenationJpn>();

        AtkSerifJudgeSpeed = false;

        PSManager = PStatusManager.GetComponent<PlayerStatusManager>();

        PlayerObject.SetActive(false);

        /*
        <EnemyStatus>
             [0]:Atk [1]:Atk Ch [2]:Mat [3]:MatCh

        <EnemyStatusF>
            [0]:HP [1]:Max HP [2]:MP [3]Max MP



            EnemyStatus[<Status ID>]
            [<Monster ID>] ⇒ 

            Exsample)
                <EnemyStatusF>
                [0] = {
                    [0] ⇒ 120
                    [1] ⇒ 100
                }
                [1] = {
                    [0] ⇒ 50
                    [1] ⇒ 200
                }

                EnemyStatusF[0][1] ⇒ 100
        */
        for(int i = 0; i < MonsterNum; i++)
        {
            EnemyName.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMName());
            EHP.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMHP());
            EmaxHP.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMmaxHP());
            EMP.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMMP());
            EmaxMP.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMmaxMP());
            EATK.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMAtk());
            EATKch.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMAtkCh());
            EMAT.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMMat());
            EMATch.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMMatCh());
            EDEF.Add(MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(i + 1).GetMDef());
        }

        /*
        <playerStatus>
             [0]:Atk [1]:Atk Ch [2]:Mat [3]:MatCh

        <playerStatusF>
            [0]:HP [1]:Max HP [2]:MP [3]Max MP

        <playerExp>
            [0]:Exp [1]:Max Exp
        */
        pHPpMPDBSetup();
        playerStatus.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetAtk);
        playerStatus.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetAtkCh);
        playerStatus.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMat);
        playerStatus.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMatCh);
        playerStatus.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetDef);
        playerExp.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetExp);
        playerExp.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMaxExp);


        Atkserif[0] = EnemyName[SelectNumAtk] + "を攻撃する";
        pHPBar.value = playerStatusF[0];
        pHPBar.maxValue = playerStatusF[1];
        hpDrawText = hpDrawGObject.GetComponent<TextMeshProUGUI>();
        hpDrawText.text = "HP[ " + pHPBar.value.ToString() + " ]";
        Enemy1Bar.maxValue = EmaxHP[0];
        Enemy1Bar.value = Enemy1Bar.maxValue;
        BattleEnemyRnd.Clear();
        MonsterID.Clear();
        
        //ワールドエリア毎 敵乱数
        if(dimention == 0)
        {
            for(int i = 0; i < 3; i++)
            {
                BattleEnemyRnd.Add(Random.Range(0, 2));
                MonsterID.Add(BattleEnemyRnd[i] + 1);
            }
        }
        else  if(dimention == 1)
        {
            for(int i = 0; i < 3; i++)
            {
                BattleEnemyRnd.Add(Random.Range(3, 5));
                MonsterID.Add(BattleEnemyRnd[i] + 1);
            }
        }
        else  if(dimention == 2)
        {
            for(int i = 0; i < 3; i++)
            {
                BattleEnemyRnd.Add(Random.Range(0, MonsterNum));
                MonsterID.Add(BattleEnemyRnd[i] + 1);
            }
        }


        Enemy1_Img.sprite = MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(MonsterID[0]).GetMImg();
        Enemy2_Img.sprite = MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(MonsterID[1]).GetMImg();
        Enemy3_Img.sprite = MonsterBook.GetComponent<MonsterBookManager>().GetMonsterStatus(MonsterID[2]).GetMImg();


    }


    // Update is called once per frame
    void Update()
    {
        if(ScriptReload == true)
        {
            SimStart();
            ScriptReload = false;
        }

        MainBattleIvent();

    }

    private void MainBattleIvent()
    {
        //Player Status Reload
        pHPBar.value = playerStatusF[0];
        pHPBar.maxValue = playerStatusF[1];
        hpDrawText.text = "HP[ " + pHPBar.value.ToString() + " ]";

        //Enemy Status Reload
        Enemy1Bar.maxValue = EmaxHP[MonsterID[0]];
        Enemy2Bar.maxValue = EmaxHP[MonsterID[1]];
        Enemy3Bar.maxValue = EmaxHP[MonsterID[2]];

        //Enemy Book Random Number

        //Debug.Log(Enemy1Bar.value.ToString());
        //Debug.Log(StartInfo.ToString() + Root.ToString() + Atk.ToString() + Magic.ToString() + Item.ToString() + RunAway.ToString());
        if(StartInfo == true)
        {
            Enemy1Bar.value = Enemy1Bar.maxValue;
            Enemy2Bar.value = Enemy2Bar.maxValue;
            Enemy3Bar.value = Enemy3Bar.maxValue;
            EHP[MonsterID[0]] = EmaxHP[MonsterID[0]];
            EHP[MonsterID[1]] = EmaxHP[MonsterID[1]];
            EHP[MonsterID[2]] = EmaxHP[MonsterID[2]];
            Debug.Log(MonsterID[0] + ":" + MonsterID[1] + ":" + MonsterID[2]);
            EnemyAnim1.SetInteger("AnimChg", (int)MonsterAnimChg.Idle);
            EnemyAnim1.SetInteger("MonsterID", MonsterID[0]);
            EnemyAnim2.SetInteger("AnimChg", (int)MonsterAnimChg.Idle);
            EnemyAnim2.SetInteger("MonsterID", MonsterID[1]);
            EnemyAnim3.SetInteger("AnimChg", (int)MonsterAnimChg.Idle);
            EnemyAnim3.SetInteger("MonsterID", MonsterID[2]);
            InfoTurnBack.GetText(EnemyName[BattleEnemyRnd[0]] + "と" + EnemyName[BattleEnemyRnd[1]] + "と" + EnemyName[BattleEnemyRnd[2]] + "は現れた");
            
            
            //Debug.Log(EHP[SelectNum].ToString() + " : " + EMP[SelectNum].ToString() + " : " + EAtk[SelectNum].ToString() + " : " + EMat[SelectNum].ToString() + " : " + EDef[SelectNum].ToString());

            if(Input.GetKeyUp(KeyCode.Return))
            {
                Root = true;
                StartInfo = false;
                CommandRoot.SetActive(true);
                Debug.Log(Root);
            }
        }
//----------------------------------------------------------------------------------------------------
//      コマンド関連 変数宣言
//----------------------------------------------------------------------------------------------------

        NowLevel = PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetLevel;
        //Vector2 Up = new Vector2(0, -1), Right = new Vector2(-1, 0), Down = new Vector2(0, 1), Left = new Vector2(1, 0);


//----------------------------------------------------------------------------------------------------
//      コマンド選択
//----------------------------------------------------------------------------------------------------
        if(Root == true)
        {
            if(SelectNum == 0)//攻撃
            {
                InfoTurnBack.GetText(CommandMenu[0]);
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {   
                    SelectedGO[3].SetActive(false);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[SelectNum + 1].SetActive(true);
                    SelectNum++;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {   
                    SelectedGO[3].SetActive(true);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[SelectNum + 1].SetActive(false);
                    SelectNum = 3;
                }
                else if(Input.GetKeyDown(KeyCode.Return))
                {
                    Root = false;
                    AtkInit = true;
                }
            }
            else if(SelectNum == 1)//魔法攻撃
            {
                InfoTurnBack.GetText(CommandMenu[1]);
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SelectedGO[SelectNum - 1].SetActive(false);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[SelectNum + 1].SetActive(true);
                    SelectNum++;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SelectedGO[SelectNum - 1].SetActive(true);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[SelectNum + 1].SetActive(false);
                    SelectNum--;
                }
                else if(Input.GetKeyDown(KeyCode.Return))
                {
                    Root = false;
                    MagicInit = true;
                }
            }
            else if(SelectNum == 2)//アイテム
            {
                InfoTurnBack.GetText(CommandMenu[2]);
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SelectedGO[SelectNum - 1].SetActive(false);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[SelectNum + 1].SetActive(true);
                    SelectNum++;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SelectedGO[SelectNum - 1].SetActive(true);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[SelectNum + 1].SetActive(false);
                    SelectNum--;
                }
                else if(Input.GetKeyDown(KeyCode.Return))
                {
                    Root = false;
                    ItemInit = true;
                }
            }
            else if(SelectNum == 3)//逃げる
            {
                InfoTurnBack.GetText(CommandMenu[3]);
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SelectedGO[SelectNum - 1].SetActive(false);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[0].SetActive(true);
                    SelectNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SelectedGO[SelectNum - 1].SetActive(true);
                    SelectedGO[SelectNum].SetActive(false);
                    SelectedGO[0].SetActive(false);
                    SelectNum--;
                }
                else if(Input.GetKeyDown(KeyCode.Return))
                {
                    Root = false;
                    RunAway = true;
                }
            }
        }
//-----------------------------------------------------------------------------------------------------
//      攻撃を選んだ場合
//-----------------------------------------------------------------------------------------------------

    AttackMethod();

//-----------------------------------------------------------------------------------------------------
//      魔法を選んだ場合
//-----------------------------------------------------------------------------------------------------
    MagicMethod();
//-----------------------------------------------------------------------------------------------------
//      アイテムを選んだ場合
//-----------------------------------------------------------------------------------------------------
        if(ItemInit == true)
        {
            CommandRoot.SetActive(false);
            CommandItem.SetActive(true);
            Item = true;
            ItemInit = false;
        }
        else if(Item == true)
        {
            if(SelectNumItem == 0)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Item = false;
                    Root = true;
                    CommandRoot.SetActive(true);
                    CommandItem.SetActive(false);

                }
            }
        }


//-----------------------------------------------------------------------------------------------------
//      逃げるを選んだ場合
//-----------------------------------------------------------------------------------------------------
        if(RunAway == true)
        {
            BTLWin.SetActive(false);
            BTLMgr.SetActive(false);
            SelectedGO[0].SetActive(true);
            SelectedGO[1].SetActive(false);
            SelectedGO[2].SetActive(false);
            SelectedGO[3].SetActive(false);
            SelectNum = 0;
            RunAway = false;
            StartInfo = true;
            CommandRoot.SetActive(false);
            PlayerStatus.SetActive(true);
            ScriptReload = true;
            PlayerObject.SetActive(true);
            subCamera.SetActive(false);
        }


//-----------------------------------------------------------------------------------------------------
//      攻撃アニメーション　終了時  取得
//-----------------------------------------------------------------------------------------------------
        if(AtkAnimEndEnemy2.GetAtkAnimEnd == true)
        {
            AtkAnimEndEnemy2.GetAtkAnimEnd = false;
            EnemyAnim1.SetInteger("AnimChg", (int)MonsterAnimChg.Idle);
            Root = true;
            CommandRoot.SetActive(true);
        }
        else if(AtkAnimEndEnemy3.GetAtkAnimEnd == true)
        {
            AtkAnimEndEnemy3.GetAtkAnimEnd = false;
            EnemyAnim1.SetInteger("AnimChg", (int)MonsterAnimChg.Idle);
            Root = true;
            CommandRoot.SetActive(true);
        }

    }

    //===============================================================================
    //      関数参照
    //===============================================================================
    partial void AttackMethod();
    partial void MagicMethod();


    private void LevelStatusUp()
    {
        float hp = Random.Range(1, 10),
            mp = Random.Range(1, 5);
        int atk = Random.Range(5, 10),
            mat = Random.Range(1, 9),
            def = Random.Range(1, 10);
         
        PSManager.GetPlayerStatus(1).GetLevel += 1;
        PSManager.GetPlayerStatus(1).GetMaxHP = PSManager.GetPlayerStatus(1).GetMaxHP + hp;                        //  HP
        PSManager.GetPlayerStatus(1).GetMaxMP = PSManager.GetPlayerStatus(1).GetMaxMP + mp;                        //  MP
        PSManager.GetPlayerStatus(1).GetAtk = PSManager.GetPlayerStatus(1).GetAtk + atk;                          //  Atk
        PSManager.GetPlayerStatus(1).GetMat = PSManager.GetPlayerStatus(1).GetMat + mat;       
        PSManager.GetPlayerStatus(1).GetDef = PSManager.GetPlayerStatus(1).GetDef + def;                   //  Mat
        PSManager.GetPlayerStatus(1).GetAtkCh = (int)Mathf.Floor( (float)PSManager.GetPlayerStatus(1).GetAtk * 1.2f );
        PSManager.GetPlayerStatus(1).GetMatCh = (int)Mathf.Floor( (float)PSManager.GetPlayerStatus(1).GetMat * 1.2f );

    }

    private void MonsterFellDown()
    {
        BTLWin.SetActive(false);
        BTLMgr.SetActive(false);
        SelectedGO[0].SetActive(true);
        SelectedGO[1].SetActive(false);
        SelectedGO[2].SetActive(false);
        SelectedGO[3].SetActive(false);
        SelectNum = 0;
        RunAway = false;
        StartInfo = true;
        CommandRoot.SetActive(false);
        PlayerStatus.SetActive(true);
        Root = false;
        Atk = false;
        SelectNumAtk = 0;
        AtkSerifSpeed = 0;
        CommandRoot.SetActive(false);
        CommandAtk.SetActive(false);
        AtkAnimEndEnemy1.GetAtkAnimEnd = false;
        AtkSerifJudgeSpeed = false;
        ScriptReload = true;
        PlayerObject.SetActive(true);
        subCamera.SetActive(false);
        return;

    }

    void pHPpMPDBSetup()
    {
        playerStatusF.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetHP);
        playerStatusF.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMaxHP);
        playerStatusF.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMP);
        playerStatusF.Add(PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetMaxMP);

    }

    void pHPDBReflect()
    {
        PSManager.GetComponent<PlayerStatusManager>().GetPlayerStatus(1).GetHP = playerStatusF[0];
    }

}
