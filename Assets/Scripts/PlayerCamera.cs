using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInput _player;


    void Update()
    {
        UpdateLook();
    }

    private void UpdateLook(){
        if(_player == null) return;
        Character character = _player.GetCharacter();
        if(character == null) return;
        transform.position = Vector3.Lerp(transform.position, character.transform.position, Time.deltaTime * _speed);
    }
}
