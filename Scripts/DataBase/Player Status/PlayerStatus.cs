using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PStatus", menuName="Create PStatus")]
public class PlayerStatus : ScriptableObject
{
    [SerializeField]
    private int id;

    [SerializeField]
    private int Level;

    [SerializeField]
    private float MaxHP;

    [SerializeField]
    private float HP;

    [SerializeField]
    private float MaxMP;

    [SerializeField]
    private float MP;

    [SerializeField]
    private int Atk;

    [SerializeField]
    private int AtkCh;

    [SerializeField]
    private int Def;

    [SerializeField]
    private int Mat;

    [SerializeField]
    private int MatCh;

    [SerializeField]
    private float MaxExp;

    [SerializeField]
    private float Exp;

    public int Getid()
    {
        
        return id;
    }

    public int GetLevel
    {
        get => Level;
        set => Level = value;
    }

    public float GetMaxHP
    {
        get => MaxHP;
        set => MaxHP = value;
    }

    public float GetHP
    {
        get => HP;
        set => HP = value;
    }

    public float GetMaxMP
    {
        get => MaxMP;
        set => MaxMP = value;
    }

    public float GetMP
    {
        get => MP;
        set => MP = value;
    }

    public int GetAtk
    {
        get => Atk;
        set => Atk = value;
    }

    public int GetAtkCh
    {
        get => AtkCh;
        set => AtkCh = value;
    }

    public int GetDef
    {
        get => Def;
        set => Def = value;
    }

    public int GetMat
    {
        get => Mat;
        set => Mat = value;
    }

    public int GetMatCh
    {
        get => MatCh;
        set => MatCh = value;
    }

    public float GetMaxExp
    {
        get => MaxExp;
        set => MaxExp = value;
    }

    public float GetExp
    {
        get => Exp;
        set => Exp = value;
    }
}
