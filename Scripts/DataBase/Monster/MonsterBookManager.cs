using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBookManager : MonoBehaviour
{
    [SerializeField]
    private MonsterBookDataBase mbDataBase;
    private Dictionary<MonsterBookStatus, int> numofMonsterBook = new Dictionary<MonsterBookStatus, int>();

    public MonsterBookStatus GetMonsterStatus(int search)
    {
        return mbDataBase.GetMStatusLists().Find(id => id.Getid() == search);
    }
}
