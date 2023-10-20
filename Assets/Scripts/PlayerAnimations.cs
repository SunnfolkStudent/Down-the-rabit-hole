using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private PlayerHealthManager _healthManager;
    private PlayerMovement _playerMovement;
    private InputManager _input;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _healthManager = GetComponent<PlayerHealthManager>();
        _playerMovement = GetComponent<PlayerMovement>();
        _input = GetComponent<InputManager>();

    }

    private void Update()
    {
        UpdatePlayerAnimation();
    }

    private void UpdatePlayerAnimation()
    {
        if (_healthManager.lives <= 0)
        {
            _animator.Play("Death");
            return;
        }

        if (!_healthManager.canTakeDamage)
        {
            _animator.Play("Hurt");
            return;
        }
        
        if (_playerMovement.IsPlayerGrounded())
        {
            _animator.Play(_input.moveDirection.x != 0 ? "Walk" : "Idle");
            if (_input.jumpPressed)
            {
                _animator.Play("Jump_Start");
            }
        }
        else
        {
            if (_rigidbody2D.velocity.y < 0 )
            {
                _animator.Play("Fall");
            }
            else
            {
                _animator.Play("Jump_Loop");
            }
            //_animator.Play(_rigidbody2D.velocity.y > 0 ? "Jump_Start" : "Fall");
        }
        if (_input.jumpPressed)
        {
            _animator.Play("Jump_Start");
        }
        
        
        
    }
}
