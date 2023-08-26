using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _moveSpeed = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y);

        Move(direction, x);
    }

    private void Move(Vector2 direction, float x)
    {
        _rb.velocity = (new Vector2(direction.x * _moveSpeed, _rb.velocity.y));
        _animator.SetFloat("speed", Mathf.Abs(x * _moveSpeed));

        if(x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if(x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
