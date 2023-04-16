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
       
        private GameObject _player;
        private Health _health;
        private Vector3 _startPosition;
        
        public bool isGuarding;
        [FormerlySerializedAs("followerDistance")] public float followDistance=5;
        // Start is called before the first frame update
        void Start()
        {
            _fighter = GetComponent<Fighter>();
            _mover = GetComponent<Mover>();
            _health = GetComponent<Health>();
            _startPosition = transform.position;

        }

        // Update is called once per frame
        void Update()
        {
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
               

            }
            else
            {
                
                _fighter.Cancel();
                if (isGuarding)
                {
                    GuardingBehaviour(_startPosition);
                }
            }
            
            
        }

        //called by unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color=Color.blue;
            Gizmos.DrawWireSphere(transform.position,followDistance);
        }

        private void GuardingBehaviour(Vector3 destination)
        {
            _mover.StartMoveAction(destination);
        } 
    }

}
