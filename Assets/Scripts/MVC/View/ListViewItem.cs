using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ListViewItem : MonoBehaviour
{
    public virtual object data { get; set; }
    Action<ListViewItem, bool> m_onValueChanged;

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

    public virtual void SetData(object data)
    {
        this.data = data;
    }

    void OnValueChanged(bool isOn)
    {
        m_onValueChanged?.Invoke(this, isOn);
    }

    public void AddValueChangedHandle(Action<ListViewItem, bool> handle)
    {
        m_onValueChanged += handle;
    }
}