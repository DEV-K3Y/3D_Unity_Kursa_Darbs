using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _default;
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Handler());
    }

    public void SetTarget(Transform value){
        _target = value;
    }

    private IEnumerator Handler(){
        while(true){
            if(_target != null){
                _agent.destination = _target.position;
            }
            else{
                if(_default != null){
                    _agent.destination = _default.position;
                } 
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
