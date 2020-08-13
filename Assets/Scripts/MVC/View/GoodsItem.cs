using System;
using UnityEngine;
using UnityEngine.UI;

public class GoodsItem : ListViewItem
{
    GoodsData m_data;

    public override object data
    {
        get => m_data;
        set => m_data = (GoodsData)value;
    }

    public Text nameText;
    public Text priceText;
    public Text BoughHintText;
    
    public void SetData(GoodsData data)
    {
        m_data = data;
        nameText.text = data.goodsName;
        priceText.text = $"{data.goodsPrice}点券";
    }

    protected override void OnClicked(bool isOn)
    {
        base.OnClicked(isOn);
    }
}
