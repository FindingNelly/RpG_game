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
        //getters
        private Transform _target;
        private ActionScheduler _actionScheduler;
        private Mover _mover;
        private Animator _animator;
        private Health _health;
        private Health _healthComponentTarget;
        
        //private variables
        private float _timeSinceLastAttack;
        
        //public variables
        public float weponRange=2;
        public float attackSpeed = 3;
        public float damage = 10;

        private void Start()
        {
            //getters
            _mover = GetComponent<Mover>();
            _actionScheduler = GetComponent<ActionScheduler>();
            _animator = GetComponent<Animator>();
            _health = GetComponent<Health>();
            
        }

        private void Update()
        {
            
            MoveToTarget();
        }

        public void MoveToTarget()
        {
            _timeSinceLastAttack += Time.deltaTime;
            //print(timeSinceLastAttack);
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
            //getting the healtcomponent
            _healthComponentTarget = _target.GetComponent<Health>();
            
            
            //attackspeed and dmg
            float timeBetweenAttack = 1 / attackSpeed;
            
            if (_timeSinceLastAttack>timeBetweenAttack)
            {
                //Trigger Hit()
                _animator.SetTrigger("attack");
                _timeSinceLastAttack = 0;
            }
            
        }

        //animationevent
        public void Hit()
        {
            if (_target == null) return;
            _healthComponentTarget.TakeDamage(damage);
            print(_healthComponentTarget.health);
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
