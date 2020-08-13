using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopData
{
    public List<GoodsData> goodsList;

    public ShopData(List<GoodsData> list)
    {
        goodsList = new List<GoodsData>();
        goodsList.AddRange(list);
    }
}

public struct GoodsData
{
    public string goodsName;
    public int goodsPrice;
    public bool isBought;

    public GoodsData(string name, int price)
    {
        goodsName = name;
        goodsPrice = price;
        isBought = false;
    }

    public void SetBoughtSign()
    {
        isBought = true;
    }
}
