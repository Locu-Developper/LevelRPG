using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="MonsterBookDataBase", menuName="Create MonsterBook DataBase")]
public class MonsterBookDataBase : ScriptableObject
{
    [SerializeField]
    private List<MonsterBookStatus> mStatusLists = new List<MonsterBookStatus>();


    public List<MonsterBookStatus> GetMStatusLists()
    {
        return mStatusLists;
    }
}
