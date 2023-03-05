using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Rigidbody _rb;
    private string _playerName;

    private Transform _checkpointPosition;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();

        _playerName = gameObject.name;

        _checkpointPosition = GameObject.Find("StartLine").transform;
    }

    void Update()
    {
        if(_playerName == "Player1")
        {
            if(Input.GetKey(KeyCode.R))
            {
                Restart();
            }
        }

        if(_playerName == "Player2")
        {
            if(Input.GetKey(KeyCode.P))
            {
                Restart();
            }
        }
    }

    private void Restart()
    {
        transform.position = _checkpointPosition.transform.position;
        FlipOver();
    }

    private void FlipOver()
    {
        transform.localRotation = Quaternion.Euler(0f,0f,0f);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void SetCheckPointPosition(Transform checkPoint)
    {
        _checkpointPosition = checkPoint;
    }
}
