using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownPlatform : MonoBehaviour
{
    private GameObject _player;
    private bool isColliding;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0)
            if (isColliding)
                StartCoroutine(DisableCollision());

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _player = collision.gameObject;
            isColliding = true;
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _player = null;
            isColliding = false;
    }

    private IEnumerator DisableCollision()
    {
        Collider2D _platform = GetComponent<Collider2D>();
        Collider2D _playerCollider = _player.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(_playerCollider, _platform);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision (_playerCollider, _platform, false);

    }
}