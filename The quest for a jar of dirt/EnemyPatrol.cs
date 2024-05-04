using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Rigidbody2D _rb;
    public Animator _animator;
    private Transform _currPoint;
    private bool isIdle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currPoint = pointA.transform;
        _animator.SetBool("IsPatrolling", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isIdle)
        {
            if (_currPoint == pointA.transform)
            {
                _rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                _rb.velocity = new Vector2(speed, 0);
            }
        }

        if (Vector2.Distance(transform.position, _currPoint.position) < 0.5f && _currPoint == pointA.transform)
        {
            StartCoroutine(StartIdle());
            _currPoint = pointB.transform;
        }

        if (Vector2.Distance(transform.position, _currPoint.position) < 0.5f && _currPoint == pointB.transform)
        {
            StartCoroutine(StartIdle());
            _currPoint = pointA.transform;
        }
    }

    private IEnumerator StartIdle()
    {
        isIdle = true;
        Vector2 tmp = _rb.velocity;
        _animator.SetBool("IsPatrolling", false);
        _rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        _rb.velocity = tmp;
        Flip();
        _animator.SetBool("IsPatrolling", true);
        isIdle = false;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}