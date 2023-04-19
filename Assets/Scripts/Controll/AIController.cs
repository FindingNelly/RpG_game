using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using RPG.Movment;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        private Fighter _fighter;
        private Mover _mover;
        private ActionScheduler _actionScheduler;
        private PathController _pathController;
       
        private GameObject _player;
        private Health _health;
        private Vector3 _startPosition;
        private float _timeSinceLastSeenPlayer;
        public float supisionTime = 2;
        public PathController patrolpath;
        
        
        public bool isGuarding;
        [FormerlySerializedAs("followerDistance")] public float followDistance=5;
        // Start is called before the first frame update
        void Start()
        {
            _fighter = GetComponent<Fighter>();
            _mover = GetComponent<Mover>();
            _health = GetComponent<Health>();
            _actionScheduler = GetComponent<ActionScheduler>();
            
            _timeSinceLastSeenPlayer = Mathf.Infinity;
            _pathController = GetComponent<PathController>();
            if (patrolpath!=null)
            {
                transform.position = patrolpath.transform.GetChild(0).position;
                _startPosition = patrolpath.transform.GetChild(0).position;
            }
            else
            {
                _startPosition = transform.position;
            }

        }

        // Update is called once per frame
        void Update()
        {
            _timeSinceLastSeenPlayer += Time.deltaTime;
            if(_health.hasDied) return;
            Move();
            
        }

        private void Move()
        {
            _player = GameObject.FindWithTag("Player");

            bool isInDistance = Vector3.Distance(_player.transform.position, transform.position) < followDistance;
            
            if (isInDistance)
            {
               _fighter.Attack(_player);
               _timeSinceLastSeenPlayer = 0;

            }
            else if(isGuarding&& _timeSinceLastSeenPlayer<supisionTime)
            {
                _actionScheduler.CancelCurrentAction();
            }
            else
            {
                PatrolBehaviour();
            }
            
            
        }

        //called by unity
        
        private void OnDrawGizmosSelected()
        {
            
            Gizmos.color=Color.blue;
            Gizmos.DrawWireSphere(transform.position,followDistance);
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = _startPosition;
            
            if (patrolpath!=null)
            {
                
                if (AtWaypoint(patrolpath.GetWaypoint(0)))
                {
                    print("yeey");
                }

                nextPosition = patrolpath.GetWaypoint(1);
            }
            
            _mover.StartMoveAction(nextPosition);
        } 
        
        private bool AtWaypoint(Vector3 targetPosition)
        {
            if (targetPosition==transform.position)
            {
                return true;
            }

            return false;
        }
         
        
    }

}
