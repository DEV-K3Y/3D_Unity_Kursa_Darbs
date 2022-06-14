using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPadAudio : MonoBehaviour
{
    [SerializeField] private PlayKind _playKind = PlayKind.OpenOnly;
    [SerializeField] private int _maxPlayCount = -1;
    [SerializeField] private TriggerPad _pad;
    [SerializeField] private AudioSource _source;

    private int _playCount = 0;

    public enum PlayKind
    {
        OpenOnly,
        CloseOnly,
        Both
    }

    void Start()
    {
        _pad.onTrigger.AddListener(OnPad);
    }

    private void OnPad(bool isOpen){
        switch (_playKind)
        {
            case PlayKind.OpenOnly:
                {
                    if (isOpen) Play();
                    break;
                }
            case PlayKind.CloseOnly:
                {
                    if (!isOpen) Play();
                    break;
                }
            case PlayKind.Both:
                {
                    Play();
                    break;
                }
        }
    }

    private void Play()
    {
        if (!_source.isPlaying)
        {
            if (_maxPlayCount < 0 || _playCount < _maxPlayCount)
            {
                _source.Play();
                _playCount++;
            }
        }
    }
}
