using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class GameStartCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        UserProxy userProxy = ApplicationFacade.applicationInstance.RetrieveProxy<UserProxy>();
        userProxy.SetAmount(10000);
        
        ApplicationFacade.applicationInstance.RegisterProxy<ShopProxy>(new ShopData(GetGoodsDataList()));
        ApplicationFacade.applicationInstance.RegisterMediator(new ShopPanelMediator("Assets/Res/Prefabs/ShopPanel.prefab"));
    }

    List<GoodsData> GetGoodsDataList()
    {
        List<GoodsData> list = new List<GoodsData>();
        list.Add(new GoodsData("物品1", 100));
        list.Add(new GoodsData("物品2", 200));
        list.Add(new GoodsData("物品3", 300));
        list.Add(new GoodsData("物品4", 400));
        list.Add(new GoodsData("物品5", 500));
        list.Add(new GoodsData("物品6", 600));
        list.Add(new GoodsData("物品7", 700));
        list.Add(new GoodsData("物品8", 800));
        list.Add(new GoodsData("物品9", 900));
        list.Add(new GoodsData("物品10", 1000));
        list.Add(new GoodsData("物品11", 1100));
        return list;
    } 
}
