using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns.Mediator;
using UnityEditor;
using UnityEngine;

public class UIPanelMediator : Mediator
{
    protected UIPanelMediator(string url) : base(url, LoadPrefab(url))
    {
        MediatorName = GetType().FullName;
    }

    static object LoadPrefab(string url)
    {
#if UNITY_EDITOR
        GameObject go = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(url));
        Transform panelTransform = go.transform;
        panelTransform.SetParent(GameObject.Find("Canvas").transform);
        panelTransform.localPosition = Vector3.zero;
        panelTransform.localScale = Vector3.one;
        go.SetActive(true);
        return panelTransform;
#endif
        return null;
    }

    protected T GetConfig<T>()
    {
        return ((Transform) ViewComponent).GetComponent<T>();
    }

    protected ApplicationFacade applicationFacade => ApplicationFacade.applicationInstance;
}
