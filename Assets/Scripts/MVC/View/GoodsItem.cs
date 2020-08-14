using System;
using UnityEngine;
using UnityEngine.UI;

public class GoodsItem : ListViewItem
{
    GoodsData m_data;
    public GoodsData goodsData => m_data;
        
    public override object data
    {
        set => m_data = (GoodsData)value;
        get => m_data;
    }

    public Text nameText;
    public Text priceText;
    public Text BoughHintText;
    
    public override void SetData(object data)
    {
        base.SetData(data);
        nameText.text = m_data.goodsName;
        priceText.text = $"{m_data.goodsPrice}点券";
        BoughHintText.gameObject.SetActive(false);
    }
}
