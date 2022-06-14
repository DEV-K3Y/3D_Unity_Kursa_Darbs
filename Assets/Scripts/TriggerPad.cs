using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPad : MonoBehaviour
{
    [SerializeField] private int[] _allowedIds;

    
[SerializeField]
    private List<Character> _characters = new List<Character>();

    public readonly Event onTrigger = new Event();
    public class Event : UnityEvent<bool>{}


    public bool GetOptionalFirstCharacter(out Character character){
        character = null;
        if(_characters.Count > 0){
            character = _characters[0];
        }
        return character != null;
    }

    void OnTriggerEnter(Collider other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if(!IsOk(character)) return;
        _characters.Add(character);
        Trigger(true);
    }

    void OnTriggerExit(Collider other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if(!IsOk(character)) return;
        _characters.Remove(character);
        Trigger(false);
    }

    public bool IsOk(Character character) {
        if(character == null) return false;
        foreach(var i in _allowedIds){
            if(i == character.GetId()){
                return true;
            }
        }
        return false;
    }

    private void Trigger(bool state){
        Debug.Log($"state:{state}");
        onTrigger.Invoke(state);
    }
}
