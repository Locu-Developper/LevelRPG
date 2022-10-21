using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject psManager;
    PlayerStatusManager PSManager;
    private GameObject player;   //(操作)移動したいオブジェクトを設定
    public Rigidbody2D rb;
    [SerializeField]Animator animator = null;
    public GameObject MapWin, BattleWin, BattleMgr;
    private bool MSRAreaIn = false;
    private float AnimTime = 0f, ResetAnimTime = 2f;

    private static float PlayerX = 0;
    private static float PlayerY = 0;

    public List<int> playerStatus = new List<int>();

    [SerializeField]
    private int rnd, rndMin, rndMax, rndMinGreater, rndMaxLess;
    //初期ステータス値
    //  MaxHP・MaxMP・Atk・Mat・Def・Exp
    public int Getrnd
    {
        get => rnd;
        set => rnd = value;
    }

    private int[] InitPLStatus =
    {
        20,
        10,
        5,
        3,
        5,
        20
    };

    //セリフスクリプト参照
    public GameObject shopEvent_Object;
    ShopEvent shopEvent;

    public GameObject Inventory_o;

    void Start()
    {
        player = GameObject.Find("主人公");
        rb = this.transform.GetComponent<Rigidbody2D>();
        transform.position = new Vector2(PlayerX, PlayerY);
        animator = GetComponent<Animator>();
        PSManager = psManager.GetComponent<PlayerStatusManager>();
        playerStatus.Add(PSManager.GetPlayerStatus(1).GetLevel);
        shopEvent = shopEvent_Object.GetComponent<ShopEvent>();
        rndMin = 1;
        rndMax = 20;
        rndMinGreater = 4;
        rndMaxLess = 4;
        StatusUp();

    }

    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        animator.speed = 0f;
        //Debug.Log(AnimTime);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 1f, 0);
            animator.speed = 0.7f;
            animator.SetFloat("x", 0);
            animator.SetFloat("y", 1);

            if(MSRAreaIn == true)
            {
                AnimTime += Time.deltaTime;
                if(AnimTime >= ResetAnimTime)
                {
                    rnd = Random.Range(rndMin,rndMax);
                    Debug.Log(rnd);

                    if(rnd >= rndMin + rndMinGreater && rnd <= rndMax - rndMaxLess)
                    {
                        ChangeWindowBattle();
                    }

                    AnimTime = 0f;
                }

            }

        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, -1f, 0);
            animator.speed = 0.7f;
            animator.SetFloat("x", 0);
            animator.SetFloat("y", -1);

            if(MSRAreaIn == true)
            {
                AnimTime += Time.deltaTime;
                if(AnimTime >= ResetAnimTime)
                {
                    rnd = Random.Range(rndMin,rndMax);
                    Debug.Log(rnd);

                    if(rnd >= rndMin + rndMinGreater && rnd <= rndMax - rndMaxLess)
                    {
                        ChangeWindowBattle();
                    }
                    AnimTime = 0f;
                }

            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(1f, 0, 0);
            animator.speed = 0.7f;
            animator.SetFloat("x", 1);
            animator.SetFloat("y", 0);

            if(MSRAreaIn == true)
            {
                AnimTime += Time.deltaTime;
                if(AnimTime >= ResetAnimTime)
                {
                    rnd = Random.Range(rndMin,rndMax);
                    Debug.Log(rnd);

                    if(rnd >= rndMin + rndMinGreater && rnd <= rndMax - rndMaxLess)
                    {
                        ChangeWindowBattle();
                    }

                    AnimTime = 0f;
                }
            }

        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-1f, 0, 0);
            animator.speed = 0.7f;
            animator.SetFloat("x", -1);
            animator.SetFloat("y", 0);

            if(MSRAreaIn == true)
            {
                AnimTime += Time.deltaTime;
                if(AnimTime >= ResetAnimTime)
                {
                    rnd = Random.Range(1,20);
                    Debug.Log(rnd);

                    if(rnd >= 7 && rnd <= 14)
                    {
                        ChangeWindowBattle();
                    }

                    AnimTime = 0f;

                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Inventory_o.SetActive(true);
        }
    }

    private void ChangeWindowBattle()
    {
        MapWin.SetActive(false);
        BattleWin.SetActive(true);
        BattleMgr.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MonsterArea"))
        {
            MSRAreaIn = true;
        }

        //weaponShop 判定
        if(other.gameObject.CompareTag("WeaponShop"))
        {
            shopEvent.GetAwsShop = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MonsterArea"))
        {
            MSRAreaIn = false;
        }

        //weaponShop 判定
        if(other.gameObject.CompareTag("WeaponShop"))
        {
            shopEvent.GetAwsShop = false;
        }

    }

    private void StatusUp()
    {
        if(playerStatus[0] == 0){
            PSManager.GetPlayerStatus(1).GetLevel = 1;
            PSManager.GetPlayerStatus(1).GetMaxHP = InitPLStatus[0];                        //  HP
            PSManager.GetPlayerStatus(1).GetMaxMP = InitPLStatus[1];                        //  MP
            PSManager.GetPlayerStatus(1).GetAtk = InitPLStatus[2];                          //  Atk
            PSManager.GetPlayerStatus(1).GetMat = InitPLStatus[3];                          //  Mat
            PSManager.GetPlayerStatus(1).GetDef = InitPLStatus[4];
            PSManager.GetPlayerStatus(1).GetAtkCh = (int)Mathf.Floor( (float)PSManager.GetPlayerStatus(1).GetAtk * 1.2f );
            PSManager.GetPlayerStatus(1).GetMatCh = (int)Mathf.Floor( (float)PSManager.GetPlayerStatus(1).GetMat * 1.2f );
            PSManager.GetPlayerStatus(1).GetHP = PSManager.GetPlayerStatus(1).GetMaxHP;   //  MaxHP
            PSManager.GetPlayerStatus(1).GetMP = PSManager.GetPlayerStatus(1).GetMaxMP;   //  MaxMP
        }
    }

}



