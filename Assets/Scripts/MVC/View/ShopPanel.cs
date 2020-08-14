using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ShopPanel : MonoBehaviour
{
    public ListView goodsList;
    public Text costText;
    public Text amountText;
    public Button buyButton;
    public GameObject goodsItemPrefab;

    int m_cost;

    void Start()
    {
        m_cost = 0;
        UpdateCost(m_cost);
    }

    public void UpdateCost(int cost)
    {
        costText.text = $"购买所需点券：{cost}";
    }

    public void AddGoods(GoodsData data)
    {
        GoodsItem item = Object.Instantiate(goodsItemPrefab).GetComponent<GoodsItem>();
        goodsList.AddItem(item);
        item.SetData(data);
        item.AddValueChangedHandle(OnGoodsItemValueChange);
    }

    void OnGoodsItemValueChange(ListViewItem item, bool isOn)
    {
        GoodsItem goodsItem = item as GoodsItem;
        m_cost += goodsItem.goodsData.goodsPrice * (isOn ? 1 : -1);
        UpdateCost(m_cost);
    }
}
