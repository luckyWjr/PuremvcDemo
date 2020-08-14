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
        userProxy.amount = 8888;
        
        ApplicationFacade.applicationInstance.RegisterAndSendCommand<ShopInitCommand>();
    }
}
