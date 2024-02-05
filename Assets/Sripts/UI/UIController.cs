using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Action OnUIUpdateEvent;

    private void Awake()
    {
        instance = this;
    }

    public void CallUiUpdateEvent()
    {
        OnUIUpdateEvent?.Invoke();    
    }
}
