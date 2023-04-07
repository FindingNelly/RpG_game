using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Movment;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        private Transform _target;
        public float weponRange=2;

        private void Update()
        {
            Action();
        }

        public void Action()
        {
            if (_target==null) return;
            print(Vector3.Distance(transform.position,_target.transform.position));
            if (Vector3.Distance(transform.position,_target.transform.position)>weponRange)
            {
                GetComponent<Mover>().MoveTo(_target.position);
                
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        public void Attack(CombatTraget combatTraget)
        {
            _target = combatTraget.transform;
            
            
        }
    }
}
