using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BattleManager
{
    partial void AttackMethod()
    {
        if(AtkInit == true)
        {
            CommandRoot.SetActive(false);
            CommandAtk.SetActive(true);
            Atk = true;
            AtkInit = false;
            Enemy1.text = EnemyName[BattleEnemyRnd[0]];
            Enemy2.text = EnemyName[BattleEnemyRnd[1]];
            Enemy3.text = EnemyName[BattleEnemyRnd[2]];
            SelectedAtk[0].SetActive(true);                    //2
            SelectedAtk[1].SetActive(false);         //0
            SelectedAtk[2].SetActive(false);      //1
            SelectNumAtk = 0;
            DamageRnd = 1.5f;
            serifAtkNum = 0;
            EnemyAtkRndMinNum = 0;
            EnemyAtkRndMaxNum = 20;
        }
        else if(Atk == true)
        {

            if(SelectNumAtk == 0)
            {
                InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {   
                    SelectedAtk[2].SetActive(false);                    //2
                    SelectedAtk[SelectNumAtk].SetActive(false);         //0
                    SelectedAtk[SelectNumAtk + 1].SetActive(true);      //1
                    SelectNumAtk++;
                    serifAtkNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {       
                    SelectedAtk[2].SetActive(true);                     //2
                    SelectedAtk[SelectNumAtk].SetActive(false);         //0
                    SelectedAtk[SelectNumAtk + 1].SetActive(false);     //1
                    SelectNumAtk = 2;
                    serifAtkNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Atk = false;
                    Root = true;
                    CommandRoot.SetActive(true);
                    CommandAtk.SetActive(false);
                    serifAtkNum = 0;
                }
                if(AtkSerifJudgeSpeed == false)
                {
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        if(AtkSerifJudgeSpeed == false)
                        {
                                AtkSerifJudgeSpeed = true;
                                Debug.Log(AtkSerifJudgeSpeed);
                                AtkSerifSpeed = 0;
                                EDamageRndJudgeOne = true;
                                EnemyCalc = true;
                                PlayerCalc = true;
                        }
                    }
                }
                else if(AtkSerifJudgeSpeed == true)
                {
                    if(EDamageRndJudgeOne == true)
                    {
                        LvAtkNum = (int)Mathf.Floor(NowLevel * DamageRnd);
                        EnemyRndNum = Random.Range(EnemyAtkRndMinNum, EnemyAtkRndMaxNum);
                        AtkDamageRnd = Random.Range(NowLevel, LvAtkNum);
                        //Debug.Log(LvAtkNum + ":" + EnemyRndNum + ":" + AtkDamageRnd);
                        Atkserif[1] = EnemyName[BattleEnemyRnd[0]] + "に" + AtkDamageRnd + "のダメージを与えた";
                        if( EnemyRndNum <= 10)
                        {
                            EnemyAtkRandom = EATKch[SelectNum];
                            Atkserif[2] = "プレイヤー" + "にクリティカルダメージが入り " + EnemyAtkRandom + " くらった";
                            //Debug.Log("Enemy Atk Critical");
                        }
                        else if(EnemyRndNum <= 20)
                        {
                            EnemyAtkRandom = Random.Range(EATK[SelectNum] / 2, EATK[SelectNum]);
                            Atkserif[2] = "プレイヤー" + "は " + EnemyAtkRandom + " ダメージくらった";
                            //Debug.Log("Enemy Atk");
                        }
                        //Debug.Log(EnemyRndNum + ":" + AtkDamageRnd);
                        EDamageRndJudgeOne = false;
                    }
                    if(AtkSerifSpeed == 0)
                    {
                        if(PlayerCalc == true)
                        {
                            serifAtkNum = 1;
                            InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                            EHP[MonsterID[0]] = EHP[MonsterID[0]] - AtkDamageRnd;
                            Enemy1Bar.value = EHP[MonsterID[0]];
                            PlayerCalc = false;
                        }

                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            if(Enemy1Bar.value <= 0)
                            {
                                if(Enemy2Bar.value > 0f || Enemy3Bar.value > 0f)
                                {
                                    AtkSerifSpeed = 1;
                                }
                                else
                                {
                                    MonsterFellDown();
                                }
                            }
                            else 
                            {
                                AtkSerifSpeed = 1;
                            }
                        }
                    }
                    else if(AtkSerifSpeed == 1)
                    {
                        if(EnemyCalc == true)
                        {
                            serifAtkNum = 2;
                            InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                            playerStatusF[0] = playerStatusF[0] - EnemyAtkRandom;
                            pHPBar.value = playerStatusF[0];
                            pHPDBReflect();
                            hpDrawText.text = "HP[ " + pHPBar.value.ToString() + " ]";
                            //Debug.Log(playerStatusF[0]);
                            EnemyCalc = false;
                        }
                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            if(pHPBar.value <= 0)
                            {
                                Root = false;
                                Atk = false;
                                SelectNumAtk = 0;
                                AtkSerifSpeed = 0;
                                CommandRoot.SetActive(false);
                                CommandAtk.SetActive(false);
                                GameOverWindow.SetActive(true);
                                AtkAnimEndEnemy1.GetAtkAnimEnd = false;
                                AtkSerifJudgeSpeed = false;
                                ScriptReload = true;
                                subCamera.SetActive(false);
                                return;
                            }
                            else 
                            {
                                Root = true;
                                Atk = false;
                                SelectNumAtk = 0;
                                AtkSerifSpeed = 0;
                                CommandRoot.SetActive(true);
                                CommandAtk.SetActive(false);
                                AtkAnimEndEnemy1.GetAtkAnimEnd = false;
                                AtkSerifJudgeSpeed = false;
                            }
                        }
                    }

                }
            }
            else if(SelectNumAtk == 1)
            {
                InfoTurnBack.GetText(Atkserif[serifAtkNum]);

                if(Input.GetKeyDown(KeyCode.DownArrow))
                {   
                    SelectedAtk[SelectNumAtk - 1].SetActive(false);     //0
                    SelectedAtk[SelectNumAtk].SetActive(false);         //1
                    SelectedAtk[SelectNumAtk + 1].SetActive(true);      //2
                    SelectNumAtk++;
                    serifAtkNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {   
                    SelectedAtk[SelectNumAtk - 1].SetActive(true);      //0
                    SelectedAtk[SelectNumAtk].SetActive(false);         //1
                    SelectedAtk[SelectNumAtk + 1].SetActive(false);     //2
                    SelectNumAtk--;
                    serifAtkNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Atk = false;
                    Root = true;
                    CommandRoot.SetActive(true);
                    CommandAtk.SetActive(false);
                }
                if(AtkSerifJudgeSpeed == false)
                {
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        if(AtkSerifJudgeSpeed == false)
                        {
                            AtkSerifJudgeSpeed = true;
                            Debug.Log(AtkSerifJudgeSpeed);
                            AtkSerifSpeed = 0;
                            EDamageRndJudgeOne = true;
                            EnemyCalc = true;
                            PlayerCalc = true;
                        }
                    }
                }
                else if(AtkSerifJudgeSpeed == true)
                {
                    if(EDamageRndJudgeOne == true)
                    {
                        LvAtkNum = (int)Mathf.Floor(NowLevel * DamageRnd);
                        EnemyRndNum = Random.Range(EnemyAtkRndMinNum, EnemyAtkRndMaxNum);
                        AtkDamageRnd = Random.Range(NowLevel, LvAtkNum);
                        //Debug.Log(LvAtkNum + ":" + EnemyRndNum + ":" + AtkDamageRnd);
                        Atkserif[1] = EnemyName[BattleEnemyRnd[1]] + "に" + AtkDamageRnd + "のダメージを与えた";
                        if( EnemyRndNum <= 10)
                        {
                            EnemyAtkRandom = EATKch[SelectNum];
                            Atkserif[2] = "プレイヤー" + "にクリティカルダメージが入り " + EnemyAtkRandom + " くらった";
                            //Debug.Log("Enemy Atk Critical");
                        }
                        else if(EnemyRndNum <= 20)
                        {
                            EnemyAtkRandom = Random.Range(EATK[SelectNum] / 2, EATK[SelectNum]);
                            Atkserif[2] = "プレイヤー" + "は " + EnemyAtkRandom + " ダメージくらった";
                            //Debug.Log("Enemy Atk");
                        }
                        //Debug.Log(EnemyRndNum + ":" + AtkDamageRnd);
                        EDamageRndJudgeOne = false;
                    }
                    if(AtkSerifSpeed == 0)
                    {
                        if(PlayerCalc == true)
                        {
                            serifAtkNum = 1;
                            InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                            EHP[MonsterID[1]] = EHP[MonsterID[1]] - AtkDamageRnd;
                            Enemy2Bar.value = EHP[MonsterID[1]];
                            PlayerCalc = false;
                        }

                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            if(Enemy2Bar.value <= 0)
                            {
                                if(Enemy1Bar.value > 0f || Enemy3Bar.value > 0f)
                                {
                                    AtkSerifSpeed = 1;
                                }
                                else
                                {
                                    MonsterFellDown();
                                }
                            }
                            else 
                            {
                                AtkSerifSpeed = 1;
                            }
                        }
                    }
                    else if(AtkSerifSpeed == 1)
                    {
                        if(EnemyCalc == true)
                        {
                            serifAtkNum = 2;
                            InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                            playerStatusF[0] = playerStatusF[0] - EnemyAtkRandom;
                            pHPBar.value = playerStatusF[0];
                            pHPDBReflect();
                            hpDrawText.text = "HP[ " + pHPBar.value.ToString() + " ]";
                            Debug.Log(playerStatusF[0]);
                            EnemyCalc = false;
                        }
                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            if(pHPBar.value <= 0)
                            {
                                Root = false;
                                Atk = false;
                                SelectNumAtk = 0;
                                AtkSerifSpeed = 0;
                                CommandRoot.SetActive(false);
                                CommandAtk.SetActive(false);
                                GameOverWindow.SetActive(true);
                                AtkAnimEndEnemy1.GetAtkAnimEnd = false;
                                AtkSerifJudgeSpeed = false;
                                ScriptReload = true;
                                subCamera.SetActive(false);
                                return;
                            }
                            else 
                            {
                                Root = true;
                                Atk = false;
                                SelectNumAtk = 0;
                                AtkSerifSpeed = 0;
                                CommandRoot.SetActive(true);
                                CommandAtk.SetActive(false);
                                AtkAnimEndEnemy1.GetAtkAnimEnd = false;
                                AtkSerifJudgeSpeed = false;
                            }
                        }
                    }

                }


            }
            else if(SelectNumAtk == 2)
            {
                InfoTurnBack.GetText(Atkserif[serifAtkNum]);

                if(Input.GetKeyDown(KeyCode.DownArrow))
                {   
                    SelectedAtk[SelectNumAtk - 1].SetActive(false);                    //2
                    SelectedAtk[SelectNumAtk].SetActive(false);         //2
                    SelectedAtk[0].SetActive(true);      //0
                    SelectNumAtk = 0;
                    serifAtkNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {   
                    SelectedAtk[SelectNumAtk - 1].SetActive(true);
                    SelectedAtk[SelectNumAtk].SetActive(false);
                    SelectedAtk[0].SetActive(false);
                    SelectNumAtk--;
                    serifAtkNum = 0;
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Atk = false;
                    Root = true;
                    CommandRoot.SetActive(true);
                    CommandAtk.SetActive(false);
                }
                if(AtkSerifJudgeSpeed == false)
                {
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        if(AtkSerifJudgeSpeed == false)
                        {
                                AtkSerifJudgeSpeed = true;
                                Debug.Log(AtkSerifJudgeSpeed);
                                AtkSerifSpeed = 0;
                                EDamageRndJudgeOne = true;
                                EnemyCalc = true;
                                PlayerCalc = true;
                        }
                    }
                }
                else if(AtkSerifJudgeSpeed == true)
                {
                    if(EDamageRndJudgeOne == true)
                    {
                        LvAtkNum = (int)Mathf.Floor(NowLevel * DamageRnd);
                        EnemyRndNum = Random.Range(EnemyAtkRndMinNum, EnemyAtkRndMaxNum);
                        AtkDamageRnd = Random.Range(NowLevel, LvAtkNum);
                        //Debug.Log(LvAtkNum + ":" + EnemyRndNum + ":" + AtkDamageRnd);
                        Atkserif[1] = EnemyName[BattleEnemyRnd[2]] + "に" + AtkDamageRnd + "のダメージを与えた";
                        if( EnemyRndNum <= 10)
                        {
                            EnemyAtkRandom = EATKch[SelectNum];
                            Atkserif[2] = "プレイヤー" + "にクリティカルダメージが入り " + EnemyAtkRandom + " くらった";
                            //Debug.Log("Enemy Atk Critical");
                        }
                        else if(EnemyRndNum <= 20)
                        {
                            EnemyAtkRandom = Random.Range(EATK[SelectNum] / 2, EATK[SelectNum]);
                            Atkserif[2] = "プレイヤー" + "は " + EnemyAtkRandom + " ダメージくらった";
                            //Debug.Log("Enemy Atk");
                        }
                        //Debug.Log(EnemyRndNum + ":" + AtkDamageRnd);
                        EDamageRndJudgeOne = false;
                    }
                    if(AtkSerifSpeed == 0)
                    {
                        if(PlayerCalc == true)
                        {
                            serifAtkNum = 1;
                            InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                            EHP[MonsterID[2]] = EHP[MonsterID[2]] - AtkDamageRnd;
                            Enemy3Bar.value = EHP[MonsterID[2]];
                            PlayerCalc = false;
                        }

                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            if(Enemy3Bar.value <= 0)
                            {
                                if(Enemy1Bar.value > 0f || Enemy2Bar.value > 0f)
                                {
                                    AtkSerifSpeed = 1;
                                }
                                else
                                {
                                    MonsterFellDown();
                                }

                            }
                            else 
                            {
                                AtkSerifSpeed = 1;
                            }
                        }
                    }
                    else if(AtkSerifSpeed == 1)
                    {
                        if(EnemyCalc == true)
                        {
                            serifAtkNum = 2;
                            InfoTurnBack.GetText(Atkserif[serifAtkNum]);
                            playerStatusF[0] = playerStatusF[0] - EnemyAtkRandom;
                            pHPBar.value = playerStatusF[0];
                            pHPDBReflect();
                            hpDrawText.text = "HP[ " + pHPBar.value.ToString() + " ]";
                            Debug.Log(playerStatusF[0]);
                            EnemyCalc = false;
                        }
                        if(Input.GetKeyDown(KeyCode.Return))
                        {
                            if(pHPBar.value <= 0)
                            {
                                Root = false;
                                Atk = false;
                                SelectNumAtk = 0;
                                AtkSerifSpeed = 0;
                                CommandRoot.SetActive(false);
                                CommandAtk.SetActive(false);
                                GameOverWindow.SetActive(true);
                                AtkAnimEndEnemy1.GetAtkAnimEnd = false;
                                AtkSerifJudgeSpeed = false;
                                ScriptReload = true;
                                subCamera.SetActive(false);
                                return;
                            }
                            else 
                            {
                                Root = true;
                                Atk = false;
                                SelectNumAtk = 0;
                                AtkSerifSpeed = 0;
                                CommandRoot.SetActive(true);
                                CommandAtk.SetActive(false);
                                AtkAnimEndEnemy1.GetAtkAnimEnd = false;
                                AtkSerifJudgeSpeed = false;
                            }
                        }
                    }

                }

            }
        }
    }

    
}
