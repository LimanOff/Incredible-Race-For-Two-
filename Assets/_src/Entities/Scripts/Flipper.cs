using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            FlipOver();
        }
    }

    private void FlipOver()
    {
        transform.localRotation = Quaternion.Euler(0f,transform.eulerAngles.y,0f);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}
