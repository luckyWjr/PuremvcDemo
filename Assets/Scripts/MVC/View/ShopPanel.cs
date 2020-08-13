using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public ListView goodsList;
    public Text costText;
    public Text amountText;
    public Button buyButton;
    public GameObject goodsItemPrefab;

    public void UpdateCost(int cost)
    {
        costText.text = $"购买所需点券：{cost}";
    }
    
    public void UpdateAmount(int amount)
    {
        amountText.text = $"当前点券：{amount}";
    }

    public void AddGoods(GoodsData data)
    {
        GoodsItem item = Object.Instantiate(goodsItemPrefab).GetComponent<GoodsItem>();
        goodsList.AddItem(item);
        item.SetData(data);
    }
}
