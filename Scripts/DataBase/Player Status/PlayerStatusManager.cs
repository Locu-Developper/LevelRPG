using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStatusDataBase psDataBase;
    private Dictionary<PlayerStatus, int> numofPlayerStatus = new Dictionary<PlayerStatus, int>();

    //public GameObject levelText;
    //private Text level;

    //void Start()
    //{
    //    levelText = GameObject.Find("Level Count");
    //    level = levelText.GetComponent<Text>();
    //    level.text = GetPlayerStatus(1).GetLevel.ToString();
    //}

    //void Update()
    //{
    //    level.text = GetPlayerStatus(1).GetLevel.ToString();
    //}

    public PlayerStatus GetPlayerStatus(int search)
    {
        return psDataBase.GetPStatusLists().Find(id => id.Getid() == search);
    }
}
