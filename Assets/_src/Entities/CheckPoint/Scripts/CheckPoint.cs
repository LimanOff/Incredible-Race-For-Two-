using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform _p1_spawnPoint;
    public Transform _p2_spawnPoint;

    private Flipper _player1;
    private Flipper _player2;

    private void Awake()
    {
        _player1 = GameObject.Find("Player1").GetComponent<Flipper>();
        _player2 = GameObject.Find("Player2").GetComponent<Flipper>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player1_Body")
        {
            _player1.SetCheckPointPosition(_p1_spawnPoint);
        }

        if (other.gameObject.name == "Player2_Body")
        {
            _player2.SetCheckPointPosition(_p2_spawnPoint);
        }
    }
}
