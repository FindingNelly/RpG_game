using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
  
    Ray _lastRay;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Camera _camera;
    

    // Start is called before the first frame update
    void Start()
    {
        //navmesh
        _navMeshAgent=GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = 5.66f;
        _navMeshAgent.acceleration = 1000;
        _navMeshAgent.angularSpeed = 4000;
        _navMeshAgent.radius=0.3f;
        
        _animator=GetComponent<Animator>();
        _camera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            MoveToCursor();
            
        }

        UpdateAnimation();
        
        //_navMeshAgent.destination = tragetTransform.position;

        void MoveToCursor()
        {
            RaycastHit hit;
            Ray ray= _camera.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                _navMeshAgent.destination = hit.point;
            }
        }

         void UpdateAnimation()
         {
             _animator.SetFloat("ForwardSpeed",transform.InverseTransformDirection(_navMeshAgent.velocity).z);
         }
    }
}
