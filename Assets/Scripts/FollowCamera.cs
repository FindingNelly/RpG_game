using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position;
    }
}
