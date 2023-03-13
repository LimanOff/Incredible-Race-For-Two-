using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    
    [SerializeField] private GameObject P1_WinPanel;
    [SerializeField] private GameObject P2_WinPanel;    

    private void Start() 
    {
        P1_WinPanel.Deactivate();
        P2_WinPanel.Deactivate();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.transform.parent.name == "Player1")
        {
            P1_WinPanel.Activate();
        }

        if(other.gameObject.transform.parent.name == "Player2")
        {
            P2_WinPanel.Activate();
        }
    }
}
