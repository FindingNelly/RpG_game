using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Mover mover;
    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
    }
    
    void MoveToCursor()
    {
        RaycastHit hit; 
        bool hasHit = Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit);
        if (hasHit)
        {
            mover.MoveTo(hit.point);        
        }
    }
}
