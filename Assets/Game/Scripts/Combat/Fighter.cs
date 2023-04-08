using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movment;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        private Transform _target;
        private ActionScheduler _actionScheduler;
        private Mover _mover;
        private Animator _animator;
        public float weponRange=2;

        private void Start()
        {
            _mover = GetComponent<Mover>();
            _actionScheduler = GetComponent<ActionScheduler>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Move();
            
        }

        public void Move()
        {
            if (_target==null) return;
            
            if (Vector3.Distance(transform.position,_target.transform.position)>weponRange)
            {
                _mover.MoveTo(_target.position);
                
            }
            else
            {
                _mover.Cancel();
                AttackBehaviour();
            }
            
        }

        public void AttackBehaviour()
        {
            _animator.SetTrigger("attack");
        }

        public void Hit()
        {
            
        }

        public void Attack(CombatTraget combatTraget)
        {
            _actionScheduler.StartAction(this);
            _target = combatTraget.transform;
            
            
        }

        public void Cancel()
        {
            _target=null;
        }
    }
}
