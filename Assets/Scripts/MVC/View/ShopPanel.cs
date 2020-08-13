using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public ListView goodsList;
    public Text amountText;
    public Button buyButton;
    public GoodsItem goodsItemPrefab;

    public void UpdateAmount(int amount)
    {
        amountText.text = $"当前点券：{amount}";
    }
}
