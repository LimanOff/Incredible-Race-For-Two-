using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public Transform StartPosition;
    public Transform EndPosition;

    public Coroutine ToEndCoroutine;
    public Coroutine ToStartCoroutine;

    public bool IsSomebodyInside;

    private IEnumerator MoveToEndPos()
    {
        yield return new WaitForSeconds(2f);
        
        while(transform.position != EndPosition.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,EndPosition.position,Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator MoveToStartPos()
    {
        yield return new WaitForSeconds(2f);

        while(transform.position != StartPosition.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,StartPosition.position,Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        other.transform.parent.gameObject.transform.parent.gameObject.transform.parent = transform;

        if(ToStartCoroutine != null)
            StopCoroutine(ToStartCoroutine);

        ToEndCoroutine = StartCoroutine(MoveToEndPos());
    }

    private void OnTriggerStay(Collider other) 
    {
        IsSomebodyInside = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        other.transform.parent.gameObject.transform.parent.gameObject.transform.parent = null;

        IsSomebodyInside = false;

        if(IsSomebodyInside == false)
        {
            if(ToEndCoroutine != null)
                StopCoroutine(ToEndCoroutine);

            ToStartCoroutine = StartCoroutine(MoveToStartPos());
        }
    }
}
