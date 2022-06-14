
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPadKillzone : MonoBehaviour
{
    [SerializeField] private TriggerPad _pad;

    private int _playCount = 0;

    void Start()
    {
        _pad.onTrigger.AddListener(OnPad);
    }

    private void OnPad(bool isOpen){
        if(isOpen){
            App.Instance.Restart();
        }
    }
}
