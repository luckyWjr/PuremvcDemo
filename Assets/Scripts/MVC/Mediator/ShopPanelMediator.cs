using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelMediator : UIPanelMediator
{
    ShopPanel m_panel;
    
    public ShopPanelMediator(string url) : base(url)
    {
        m_panel = GetPanel<ShopPanel>();
        m_panel.buyButton.onClick.AddListener(Buy);
    }

    public override void OnRegister()
    {
        base.OnRegister();
        applicationFacade.SendCommand<RefreshGoodsUICommand>();
    }

    public void AddGoods(GoodsData data)
    {
        m_panel.AddGoods(data);
    }
    
    public void UpdateAmount(int amount)
    {
        m_panel.amountText.text = $"当前点券：{amount}";
    }

    void Buy()
    {
        applicationFacade.SendCommand<BuyCommand>();
    }
}
