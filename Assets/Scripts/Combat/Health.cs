using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{

    public class Health : MonoBehaviour
    {
        public float health = 100;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(float damage)
        {
            health = MathF.Max(health-damage, 0);
        }
    }
}