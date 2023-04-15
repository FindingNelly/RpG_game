using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace RPG.Combat
{

    public class Health : MonoBehaviour
    {
        //getters
        private Animator _animator;
        
        //public variables
        public float health = 100;
        
        //private variables
        public bool hasDied;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            hasDied = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsDead()
        {
            return hasDied;
        }

        public void TakeDamage(float damage)
        {
            
            health = MathF.Max(health-damage, 0);
            if (health==0)
            {
                
                Die();
            }
        }

        public void Die()
        {
            if(hasDied) return;
            hasDied = true;
            _animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            


        }
    }
}