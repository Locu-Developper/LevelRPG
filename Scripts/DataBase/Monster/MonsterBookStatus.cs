using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="MStatus", menuName="Create Monster Status")]
public class MonsterBookStatus : ScriptableObject
{
    [SerializeField]
    private int id;

    [SerializeField]
    private string MName;

    [SerializeField]
    private Sprite MImg;

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
    private int Mat;

    [SerializeField]
    private int MatCh;

    [SerializeField]
    private int Def;

    public int Getid()
    {
        
        return id;
    }

    public string GetMName()
    {
        return MName;
    }

    public Sprite GetMImg()
    {
        return MImg;
    }

    public float GetMmaxHP()
    {
        return MaxHP;
    }

    public float GetMHP()
    {
        return HP;
    }

    public float GetMmaxMP()
    {
        return MaxMP;
    }

    public float GetMMP()
    {
        return MP;
    }

    public int GetMAtk()
    {
        return Atk;
    }

    public int GetMAtkCh()
    {
        return AtkCh;
    }

    public int GetMMat()
    {
        return Mat;
    }

    public int GetMMatCh()
    {
        return MatCh;
    }

    public int GetMDef()
    {
        return Def;
    }

}
