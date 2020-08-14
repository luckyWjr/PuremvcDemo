using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class ShopInitCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        UserProxy userProxy = ApplicationFacade.applicationInstance.RetrieveProxy<UserProxy>();
        ApplicationFacade.applicationInstance.RegisterProxy<ShopProxy>(new ShopData(GetGoodsDataList()));
        ShopPanelMediator shopPanelMediator = ApplicationFacade.applicationInstance.RegisterAndRetrieveMediator<ShopPanelMediator>("Assets/Res/Prefabs/ShopPanel.prefab");
        shopPanelMediator.UpdateAmount(userProxy.amount);
        
        ApplicationFacade.applicationInstance.RegisterAndSendCommand<RefreshGoodsUICommand>();
        ApplicationFacade.applicationInstance.RegisterCommand<BuyCommand>();
    }
    
    List<GoodsData> GetGoodsDataList()
    {
        List<GoodsData> list = new List<GoodsData>
        {
            new GoodsData("物品1", 100),
            new GoodsData("物品2", 200),
            new GoodsData("物品3", 300),
            new GoodsData("物品4", 400),
            new GoodsData("物品5", 500),
            new GoodsData("物品6", 600),
            new GoodsData("物品7", 700),
            new GoodsData("物品8", 800),
            new GoodsData("物品9", 900),
            new GoodsData("物品10", 1000),
            new GoodsData("物品11", 1100)
        };
        return list;
    }
}
