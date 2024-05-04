using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private Animator _animator;
    private Transform _currPoint;
    public bool isIdle = true;
    public bool isDone = true;
    [SerializeField] float speed;
    
    void Start()
    {
        _currPoint = pointB.transform;
        
    }

    
    void Update()
    {
        if(!isIdle)
        {
            transform.position = Vector2.Lerp(transform.position, _currPoint.transform.position, speed * Time.deltaTime);
            _animator.SetBool("IsSailing", true);
        }
        
        if (Vector2.Distance(transform.position, _currPoint.position) < 0.5f && _currPoint == pointA.transform)
        {
            _currPoint = pointB.transform;
            _animator.SetBool("IsSailing", false);
            isIdle = true;
            StartCoroutine(Flip());
        }
        if (Vector2.Distance(transform.position, _currPoint.position) < 0.5f && _currPoint == pointB.transform)
        {
            _currPoint = pointA.transform;
            _animator.SetBool("IsSailing", false);
            isIdle = true;
            StartCoroutine(Flip());
        }
    }

    
    private IEnumerator Flip()
    {
        yield return new WaitForSeconds(1f);
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        isDone = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if((isIdle && isDone) || (!isIdle && !isDone))
                other.transform.SetParent(transform);
            else if(isIdle && !isDone)
                other.transform.SetParent(null);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
