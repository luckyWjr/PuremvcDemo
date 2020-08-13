using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelMediator : UIPanelMediator
{
    ShopPanel m_panel;
    
    public ShopPanelMediator(string url) : base(url)
    {
        m_panel = GetConfig<ShopPanel>();
        m_panel.buyButton.onClick.AddListener(Buy);
    }

    public override void OnRegister()
    {
        base.OnRegister();
        applicationFacade.SendCommand<RefreshGoodsUICommand>();
    }
    
    // public void AddGoods

    void Buy()
    {
        
    }
}
