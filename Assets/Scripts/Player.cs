using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;

    private const string AnimatorKeySpeed = "Speed";

    void Update()
    {
        float speed = _character.GetCurrentNormalizedSpeed();
        _animator.SetFloat(AnimatorKeySpeed, speed);
    }
}
