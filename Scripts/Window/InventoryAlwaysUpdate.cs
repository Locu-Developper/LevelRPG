using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAlwaysUpdate : MonoBehaviour
{
    public GameObject eShop;
    ShopEvent _sEvent;

    void Start()
    {
        _sEvent = eShop.GetComponent<ShopEvent>();
    }

    public void AlwaysUpdate()
    {
        _sEvent.GetAwsShop = false;
    }
}
