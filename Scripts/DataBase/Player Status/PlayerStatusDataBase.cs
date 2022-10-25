using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerStatusDataBase", menuName="Create PlayerStatus DataBase")]
public class PlayerStatusDataBase : ScriptableObject
{
    [SerializeField]
    private List<PlayerStatus> pStatusLists = new List<PlayerStatus>();


    public List<PlayerStatus> GetPStatusLists()
    {
        return pStatusLists;
    }
}
