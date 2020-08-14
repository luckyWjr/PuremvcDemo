using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class UIPanelMediator : Mediator
{
    class NotificationEvent
    {
        public bool isReceiveOnEnable;
        public Action<INotification> NotiEvent;
    }

    GameObject m_gameObject;
    Transform m_transform;
    bool m_isVisible;
    Dictionary<string, NotificationEvent> m_notificationEventDic;

    public GameObject gameObject => m_gameObject;

    public Transform transform => m_transform;
    
    public bool isVisible
    {
        get => m_isVisible;
        set
        {
            if (m_isVisible != value)
            {
                m_isVisible = value;
                gameObject.SetActive(m_isVisible);
            }
        }
    }
    
    protected UIPanelMediator(string url) : base(url)
    {
        LoadPrefab(url);
        MediatorName = GetType().FullName;
        m_notificationEventDic = new Dictionary<string, NotificationEvent>();
        RegisterNotifications();
        isVisible = true;
    }

    void LoadPrefab(string url)
    {
#if UNITY_EDITOR
        m_gameObject = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(url));
        m_transform = m_gameObject.transform;
        m_transform.SetParent(GameObject.Find("Canvas").transform);
        m_transform.localPosition = Vector3.zero;
        m_transform.localScale = Vector3.one;
#endif
    }

    protected T GetPanel<T>()
    {
        return gameObject.GetComponent<T>();
    }

    protected ApplicationFacade applicationFacade => ApplicationFacade.applicationInstance;
    
    protected virtual void RegisterNotifications() { }
    
    protected void RegisterNotification(string name, Action<INotification> notiEvent, bool isReceiveOnVisible = false)
    {
        m_notificationEventDic[name] = new NotificationEvent
        {
            isReceiveOnEnable = isReceiveOnVisible,
            NotiEvent = notiEvent
        };
    }
    
    public override string[] ListNotificationInterests()
    {
        return m_notificationEventDic.Keys.ToArray();
    }
    
    public override void HandleNotification(INotification notification)
    {
        if (m_notificationEventDic.TryGetValue(notification.Name, out NotificationEvent notiEvent))
        {
            if (notiEvent.isReceiveOnEnable)
            {
                if (isVisible)
                    notiEvent.NotiEvent?.Invoke(notification);
            }
            else
                notiEvent.NotiEvent?.Invoke(notification);
        }
    }
}
