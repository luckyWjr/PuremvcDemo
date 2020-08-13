using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ListViewItem : MonoBehaviour
{
    public virtual object data { get; set; }
    public Action<ListViewItem, bool> onValueChanged;

    Toggle m_toggle;
    public Toggle toggle
    {
        get
        {
            if (m_toggle == null)
                m_toggle = GetComponent<Toggle>();
            return m_toggle;
        }
    }

    public bool isOn
    {
        set => toggle.isOn = value;
        get => toggle.isOn;
    }

    void Awake()
    {
        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(bool isOn)
    {
        onValueChanged?.Invoke(this, isOn);
        OnClicked(isOn);
    }

    protected virtual void OnClicked(bool isOn)
    {
        
    }
}