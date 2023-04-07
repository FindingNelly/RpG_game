using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movment
{
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
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = 5.66f;
            _navMeshAgent.acceleration = 1000;
            _navMeshAgent.angularSpeed = 4000;
            _navMeshAgent.radius = 0.3f;

            _animator = GetComponent<Animator>();
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {


            UpdateAnimation();

          
        }
        
        void UpdateAnimation()
        {
            _animator.SetFloat("ForwardSpeed", transform.InverseTransformDirection(_navMeshAgent.velocity).z);
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }

        public void MoveTo(Vector3 destination)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.destination = destination;
        }
    }
}
