using System;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Mediator;
using PureMVC.Patterns.Proxy;
using UnityEngine;

public class ApplicationFacade : Facade
{
    static ApplicationFacade m_applicationInstance;

    public static ApplicationFacade applicationInstance
    {
        get
        {
            if (m_applicationInstance == null)
            {
                if (instance == null) instance = new ApplicationFacade();
                m_applicationInstance = instance as ApplicationFacade;
            }
            return m_applicationInstance;
        }
    }

    public void Launch()
    {
        SendCommand<GameStartCommand>();
    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy<UserProxy>(new UserData());
    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand<GameStartCommand>();
    }

    public T RegisterAndRetrieveProxy<T>(object data) where T : Proxy
    {
        RegisterProxy<T>(data);
        return RetrieveProxy<T>();
    }
    
    
    public void RegisterProxy<T>(object data) where T : Proxy
    {
        T proxy = Activator.CreateInstance(typeof(T), new object[] { typeof(T).FullName, data }) as T;
        RegisterProxy(proxy);
    }

    public T RetrieveProxy<T>() where T : Proxy
    {
        return RetrieveProxy(typeof(T).FullName) as T;
    }
    
    public void RegisterAndSendCommand<T>(object body = null, string type = null) where T : SimpleCommand, new()
    {
        RegisterCommand<T>();
        SendCommand<T>(body, type);
    }
    
    public void RegisterCommand<T>() where T : SimpleCommand, new()
    {
        RegisterCommand(typeof(T).FullName, () => new T());
    }
    
    public void SendCommand<T>(object body = null, string type = null) where T : SimpleCommand
    {
        SendNotification(typeof(T).FullName, body, type);
    }

    public T RegisterAndRetrieveMediator<T>(string url) where T : UIPanelMediator
    {
        RegisterMediator<T>(url);
        return RetrieveMediator<T>();
    }
    
    public void RegisterMediator<T>(string url) where T : UIPanelMediator
    {
        T uiPanel = Activator.CreateInstance(typeof(T), url) as T;
        RegisterMediator(uiPanel);
    }

    public T RetrieveMediator<T>() where T : Mediator
    {
        return RetrieveMediator(typeof(T).FullName) as T;
    }
}
