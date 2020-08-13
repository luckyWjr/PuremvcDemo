using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class RefreshGoodsUICommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        ShopProxy shopProxy = ApplicationFacade.applicationInstance.RetrieveProxy<ShopProxy>();
        
        ShopPanelMediator shopPanelMediator = ApplicationFacade.applicationInstance.RetrieveMediator<ShopPanelMediator>();

        foreach (var goodsData in shopProxy.goodsList)
        {
            // shopPanelMediator.
        }
    }
}
