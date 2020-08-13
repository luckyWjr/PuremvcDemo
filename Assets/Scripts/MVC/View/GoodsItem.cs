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
    
    public override void SetData(object data)
    {
        base.SetData(data);
        nameText.text = m_data.goodsName;
        priceText.text = $"{m_data.goodsPrice}点券";
    }

    protected override void OnItemValueChanged(bool isOn)
    {
        base.OnItemValueChanged(isOn);
    }
}
