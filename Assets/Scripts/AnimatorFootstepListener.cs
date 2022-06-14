using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFootstepListener : MonoBehaviour
{
    [SerializeField] private AudioClip[] _steps;


    public void AnimatorFootstep()
    {
        PlayFootstepSound();
    }

    public void AnimatorFootstepRun()
    {
        PlayFootstepSound();
    }

    private void PlayFootstepSound()
    {
        AudioClip clip = _steps[Random.Range(0, _steps.Length)];
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
