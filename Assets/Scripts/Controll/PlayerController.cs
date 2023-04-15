using RPG.Combat;
using RPG.Movment;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.Control

{
    public class PlayerController : MonoBehaviour
    {
    
       
        Camera _camera;
        private Mover _mover;
        private Fighter _fighter;
        private Animator _animator;
        
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _camera = Camera.main;
            _mover = GetComponent<Mover>();
            _fighter = GetComponent<Fighter>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Combat()) return;
            if (Move()) return;
            
            
        }

        private bool Move()
        {
            RaycastHit hit; 
            bool hasHit = Physics.Raycast(GetMouseRay, out hit);
            
            if (hasHit&&hit.collider.CompareTag("Walkable"))
            { 
                
                if (Input.GetMouseButton(0))
                {
                   
                    _mover.StartMoveAction(hit.point);
                    
                }

                return true;
            }

            return false;

        }

        private Ray GetMouseRay => _camera.ScreenPointToRay(Input.mousePosition);

        private  bool Combat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay);
            foreach (RaycastHit hit in hits)
            {
                CombatTraget target = hit.transform.GetComponent<CombatTraget>();
                if(target==null) continue;
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _fighter.Attack(hit.transform.GetComponent<CombatTraget>().GameObject());
                    }

                    return true;
                }
            }

            return false;
        }
    }

}