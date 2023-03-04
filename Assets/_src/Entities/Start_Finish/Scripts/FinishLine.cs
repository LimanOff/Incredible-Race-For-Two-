using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static Action OnPlayerTouchFinishLine;

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{other.gameObject.transform.parent} WIN!");

        OnPlayerTouchFinishLine?.Invoke();
    }
}
