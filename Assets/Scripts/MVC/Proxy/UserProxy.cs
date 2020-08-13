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
    
    public void SetAmount(int amount)
    {
        m_userData.amount = amount;
    }

    public void ReduceAmount(int amount)
    {
        m_userData.amount -= amount;
    }
}
