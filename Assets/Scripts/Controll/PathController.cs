using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PathController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            Vector3 size = new Vector3(0.2f, 0.2f, 2f);
            for (int i = 0; i < transform.childCount;i++)
            {
                Gizmos.color=Color.grey;
                Gizmos.DrawCube(GetWaypoint(i),new Vector3(0.3f, 0.3f, 0.3f));
                Gizmos.DrawLine(GetWaypoint(i),GetNextIndex(i));
            }
        }

        private Vector3 GetNextIndex(int i)
        {
            if (transform.childCount==i+1)
            {
                return transform.GetChild(0).position;
                
                
            }
            return transform.GetChild(i+1).position;
            
        }

        private Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
