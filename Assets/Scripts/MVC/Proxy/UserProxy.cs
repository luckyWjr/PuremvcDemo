using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Proxy;
using UnityEngine;

public class UserProxy : Proxy
{
    UserData m_userData;
    
    public UserProxy(string proxyName, object data = null) : base(proxyName, data)
    {
        m_userData = data as UserData;
    }

    public int amount
    {
        get => m_userData.amount;
        set => m_userData.amount = value;
    }
}
