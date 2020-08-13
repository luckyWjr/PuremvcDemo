using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ListView : MonoBehaviour
{
    public enum ESelectType
    {
        Single,
        Multiple
    }

    public ESelectType selectType;
    
    Transform m_transform;
    GridLayoutGroup m_gridLayoutGroup;
    
    List<ListViewItem> m_itemList;
    public List<ListViewItem> itemList => m_itemList;

    List<ListViewItem> m_selectedItemList;
    
    void Start()
    {
        m_transform = transform;
        m_gridLayoutGroup = GetComponent<GridLayoutGroup>();
        
        m_itemList = new List<ListViewItem>();
        m_selectedItemList = new List<ListViewItem>();
    }
    
    public void AddItem(ListViewItem item)
    {
        m_itemList.Add(item);
        item.transform.SetParent(m_transform);
        item.onValueChanged = OnValueChanged;
    }

    void OnValueChanged(ListViewItem item, bool isOn)
    {
        if (isOn)
        {
            if (selectType == ESelectType.Single)
            {
                foreach (var selectedItem in m_selectedItemList)
                    selectedItem.isOn = false;
                m_selectedItemList.Clear();
                m_selectedItemList.Add(item);
            }
            else
                m_selectedItemList.Add(item);
        }
        else
        {
            if (selectType == ESelectType.Single)
                m_selectedItemList.Clear();
            else
                m_selectedItemList.Remove(item);
        }
    }
}
