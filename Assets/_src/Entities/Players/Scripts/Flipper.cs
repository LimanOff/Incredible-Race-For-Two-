using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Rigidbody _rb;
    private string _playerName;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();

        _playerName = gameObject.name;
    }

    void Update()
    {
        if(_playerName == "Player1")
        {
            if(Input.GetKey(KeyCode.R))
            {
                FlipOver();
            }
        }

        if(_playerName == "Player2")
        {
            if(Input.GetKey(KeyCode.P))
            {
                FlipOver();
            }
        }
    }

    private void FlipOver()
    {
        transform.localRotation = Quaternion.Euler(0f,transform.eulerAngles.y,0f);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}
