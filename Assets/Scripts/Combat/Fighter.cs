using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movment;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        //getters
        public Health target;
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
            if(target==null) return;
            
            MoveToTarget();
        }

        public void MoveToTarget()
        {
            _timeSinceLastAttack += Time.deltaTime;
            //print(timeSinceLastAttack);
            if (target==null) return;
            
            
            
            if (Vector3.Distance(transform.position,target.transform.position)>weponRange || target.hasDied)
            {
                
                _mover.MoveTo(target.transform.position);
                
            }
            else
            {
                _mover.Cancel();
                AttackBehaviour();
                
               
            }
            
        }

        public void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            
            if (target.hasDied) 
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
            
            if (target == null) return;
            target.TakeDamage(damage);
            print(target.health);
           
        }

        public void Attack(GameObject combatTraget)
        {
            
            _actionScheduler.StartAction(this);
            target = combatTraget.GetComponent<Health>();
            
            
        }

        public void Cancel()
        {
            
            
            target=null;
        }

       
    }
}
