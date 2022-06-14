
using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private TriggerPad _pad;
    [SerializeField] private Transform _door;

    [SerializeField] private bool _isOpen;
    [SerializeField] private float _speed;
    [Range(0f, 1f)]
    [SerializeField] private float _progress;
    [SerializeField] private Transform _open;
    [SerializeField] private Transform _closed;

    private IEnumerator _handler;

#if UNITY_EDITOR
    void OnValidate()
    {
        if(Application.isPlaying) return;
        UpdateRawDoorPos();
    }
#endif


    // Start is called before the first frame update
    void Start()
    {
        _pad.onTrigger.AddListener(OnPad);
        OnPad(_isOpen);
    }

    private void OnPad(bool isOpen){
        SetIsOpen(isOpen);
    }

    private void UpdateRawDoorPos(){
        if(!IsRefsGood()) return;
        _door.position = Vector3.Lerp(_closed.position, _open.position, _progress);
    }

    private void SetIsOpen(bool value){
        _isOpen = value;
        if(_handler != null){
            Debug.Log("door animation already active");
            return;
        }
        _handler = HandleDoorSmoothMovement();
        Debug.Log("door animation starting..");
        StartCoroutine(_handler);
    }

    private bool IsRefsGood(){
        if(_door == null) return false;
        if(_open == null || _closed == null) return false;
        return true;
    }

    private IEnumerator HandleDoorSmoothMovement(){
        while(true){
            if(!IsRefsGood()) break;

            _progress = Mathf.MoveTowards(_progress, _isOpen ? 1f : 0f, Time.deltaTime * _speed);
            UpdateRawDoorPos();

            Vector3 destination = _isOpen ? _open.position : _closed.position;
            if(_door.position == destination){
                break;
            }
            
            yield return null;
        }
        _handler = null;
        Debug.Log("door animation completed");
    }


}
