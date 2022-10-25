using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour
{

    public GameObject MapWin, BattleWin;
    private bool MSRAreaIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MSRAreaIn == true)
        {
            int rnd = Random.Range(1,20);
            Debug.Log(rnd);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MonsterArea"))
        {
            MSRAreaIn = true;
            //if(rnd >= 7 && rnd <= 14)
            //{
            //    MapWin.SetActive(false);
            //    BattleWin.SetActive(true);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MonsterArea"))
        {
            MSRAreaIn = false;
        }

    }
}
