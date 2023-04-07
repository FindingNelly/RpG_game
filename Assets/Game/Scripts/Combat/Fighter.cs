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
        public float weponRange=2;

        private void Start()
        {
            _actionScheduler = GetComponent<ActionScheduler>();
        }

        private void Update()
        {
            Action();
        }

        public void Action()
        {
            if (_target==null) return;
            
            if (Vector3.Distance(transform.position,_target.transform.position)>weponRange)
            {
                GetComponent<Mover>().MoveTo(_target.position);
                
            }
            else
            {
                GetComponent<Mover>().Cancel();
            }
            
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
