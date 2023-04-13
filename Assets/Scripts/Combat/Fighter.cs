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
        Health _target;
        private ActionScheduler _actionScheduler;
        private Mover _mover;
        private Animator _animator;
        
        
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
            


        }

        private void Update()
        {
            if(_target==null) return;
            
            MoveToTarget();
        }

        public void MoveToTarget()
        {
            _timeSinceLastAttack += Time.deltaTime;
            //print(timeSinceLastAttack);
            if (_target==null) return;
            
            
            
            if (Vector3.Distance(transform.position,_target.transform.position)>weponRange || _target.hasDied)
            {
                _mover.MoveTo(_target.transform.position);
                
            }
            else
            {
                AttackBehaviour();
                _mover.Cancel();
               
            }
            
        }

        public void AttackBehaviour()
        {
            transform.LookAt(_target.transform);
            
            if (_target.hasDied) 
            {
                _animator.ResetTrigger("attack");
                _animator.SetTrigger("stopAttacking");
                return;
            }
           
            
            //Attackspeed and dmg
            float timeBetweenAttack = 1 / attackSpeed;
            
            if (_timeSinceLastAttack>timeBetweenAttack)
            {
                //Trigger Hit()
                _animator.ResetTrigger("stopAttacking");
                _animator.SetTrigger("attack");
                
                _timeSinceLastAttack = 0;
            }
            
        }

        //animationevent
        public void Hit()
        {
            
            if (_target == null) return;
            _target.TakeDamage(damage);
            print(_target.health);
           
        }

        public void Attack(CombatTraget combatTraget)
        {
            
            _actionScheduler.StartAction(this);
            _target = combatTraget.GetComponent<Health>();
            
            
        }

        public void Cancel()
        {
            
            
            _target=null;
        }

       
    }
}
