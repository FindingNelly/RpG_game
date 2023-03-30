using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]  Transform tragetTransform;
    Ray _lastRay;

    NavMeshAgent _navMeshAgent;
   
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent=GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        Debug.DrawRay(_lastRay.origin,_lastRay.direction*100);
        _navMeshAgent.destination = tragetTransform.position;
    }
}
