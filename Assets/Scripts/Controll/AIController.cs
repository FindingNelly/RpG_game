using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using RPG.Movment;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        private Fighter _fighter;
        private Mover _mover;
        private NavMeshAgent _navMeshAgent;
        private GameObject _player;
        private Health _health;
        
        public float distacePlayer=5;
        // Start is called before the first frame update
        void Start()
        {
            _fighter = GetComponent<Fighter>();
            _mover = GetComponent<Mover>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

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

            bool isInDistance = Vector3.Distance(_player.transform.position, transform.position) < distacePlayer;
            print(isInDistance);
            if (isInDistance)
            {
               _fighter.Attack(_player);
               

            }
            else
            {
                
                _fighter.Cancel();
            }

            

        }
    }

}
