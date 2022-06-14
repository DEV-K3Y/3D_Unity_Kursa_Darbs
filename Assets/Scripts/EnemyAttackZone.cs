using System.Runtime;
using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private TriggerPad _pad;

    // Start is called before the first frame update
    void Start()
    {
        _pad.onTrigger.AddListener(OnPad);
    }

    private void OnPad(bool isOpen){
        Character target = null;

        if(isOpen){
            _pad.GetOptionalFirstCharacter(out target);
        }
        SetTargetForEnemies(target == null ? null : target.transform);
    }

    private void SetTargetForEnemies(Transform tr){
        foreach(var i in _enemies){
            i.SetTarget(tr);
        }
    }
}
