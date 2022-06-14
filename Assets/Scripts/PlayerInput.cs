using System;
using System.Net.Mime;
using System.Data.Common;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character _character;
    [Header("___Input___")]
    [SerializeField] private KeyCode[] _forward;
    [SerializeField] private KeyCode[] _backward;
    [SerializeField] private KeyCode[] _right;
    [SerializeField] private KeyCode[] _left;
    [Header("___Characters___")]
    [SerializeField] private CharacterSwitchData[] _characters;

    public Character GetCharacter() => _character;

    [System.Serializable]
    private class CharacterSwitchData{
        public KeyCode keyCode;
        public Character character;
    }

    void Update()
    {
        UpdateCharacterSwitch();
        UpdateCharacterInput();

        if(Input.GetKeyDown(KeyCode.Escape)){
            App.Instance.Quit();
        }
    }

    private void UpdateCharacterInput() {
        if(_character == null) return;

        bool forward = IsAnyKeyActive(_forward);
        bool backward = IsAnyKeyActive(_backward);
        bool right = IsAnyKeyActive(_right);
        bool left = IsAnyKeyActive(_left);

        bool upDown = !(forward && backward) && (forward || backward);
        bool leftRight = !(right && left) && (right || left);

        //Debug.Log($"forward[{forward}] backward[{backward}] right[{right}] left[{left}] upDown[{upDown}] leftRight[{leftRight}]");

        if(upDown || leftRight){
            Vector3 direction = Vector3.zero;

            if(forward){
                direction.z += 1f;
            }
            if(backward){
                direction.z += -1f;
            }

            if(right){
                direction.x += 1f;
            }
            if(left){
                direction.x += -1f;
            }

            _character.MoveInDirection(direction);
        }
    }

    private void UpdateCharacterSwitch() {
        if(_characters == null) return;

        int length = _characters.Length;
        for(int i = 0; i < length; i++){
            CharacterSwitchData data = _characters[i];
            if(Input.GetKeyDown(data.keyCode)){
                _character = data.character;
                break;
            }
        }
    }

    private bool IsAnyKeyActive(KeyCode[] keys){
        if(keys == null) return false;
        int length = keys.Length;
        for(int i = 0; i < length; i++){
            if(Input.GetKey(keys[i])){
                return true;
            }
        }
        return false;
    }
}
