using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movment
{
    public class Mover : MonoBehaviour, IAction
    {

        Ray _lastRay;

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Camera _camera;
        private ActionScheduler _actionScheduler;


        // Start is called before the first frame update
        void Start()
        {
            //navmesh
            _navMeshAgent = GetComponent<NavMeshAgent>();
            
            _actionScheduler = GetComponent<ActionScheduler>();

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

        public void StartMoveAction(Vector3 destination)
        {
            _actionScheduler.StartAction(this);
            MoveTo(destination);
        }
        public void Cancel()
        {
            
            _navMeshAgent.isStopped = true;
        }

        public void MoveTo(Vector3 destination)
        {
            
            _animator.SetTrigger("stopAttacking");
            _navMeshAgent.destination = destination;
            _navMeshAgent.isStopped = false;
        }
    }
}
