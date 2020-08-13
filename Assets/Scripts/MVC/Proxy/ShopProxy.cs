using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;

public class ShopProxy : Proxy
{
    ShopData m_shopData;

    public ShopProxy(string proxyName, object data = null) : base(proxyName, data)
    {
        m_shopData = data as ShopData;
    }

    public List<GoodsData> goodsList => m_shopData.goodsList;
}
