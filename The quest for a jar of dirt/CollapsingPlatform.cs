using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    [SerializeField] private float downTime;
    [SerializeField] private float collapsingTime;
    private Animator _animator;
    private bool _isDone = true;

    private Collider2D _platform;
    // Start is called before the first frame update
    private void Awake()
    {
        _platform = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")) && _isDone)
        {
            _isDone = false;
            StartCoroutine(Collapse());
        }
    }

    private IEnumerator Collapse()
    {
        
        yield return new WaitForSeconds(collapsingTime);
        _animator.SetBool("IsCollapsing", true);
        _platform.enabled = false;
        yield return new WaitForSeconds(downTime);
        _animator.SetBool("IsCollapsing", false);
        _platform.enabled = true;
        _isDone = true;
    }
}
