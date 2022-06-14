
using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private CanvasGroup _tmpTitle;

    private bool _isShowing = false;

    public void Show(float waitTime, UnityAction onCompleted){
        if(_isShowing) return;
        _isShowing = true;
        StartCoroutine(Handle(waitTime, onCompleted));
    }

    private IEnumerator Handle(float waitTime, UnityAction onCompleted){

        // Load black screen
        while(_canvasGroup.alpha < 1f){
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, 1f, Time.deltaTime * 0.5f);
            yield return null;
        }

        // Fade in text
        while(_tmpTitle.alpha < 1f){
            _tmpTitle.alpha = Mathf.MoveTowards(_tmpTitle.alpha, 1f, Time.deltaTime * 1f);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);
        onCompleted.Invoke();
    }
}
