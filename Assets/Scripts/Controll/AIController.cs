using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
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
        
        public float distacePlayer=5;
        // Start is called before the first frame update
        void Start()
        {
            _fighter = GetComponent<Fighter>();
            _mover = GetComponent<Mover>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private bool Move()
        {
            _player = GameObject.FindWithTag("Player");
            if (_player == null) return false;
            if (Vector3.Distance(_player.transform.position,transform.position)<distacePlayer)
            {
               _fighter.MoveToTarget();
                
            }

            return false;

        }
    }

}
