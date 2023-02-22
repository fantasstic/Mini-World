using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private bool _isAttack;
    private Collider _enemyCollider;
    private Animator _animator;

    private void Start()
    {
        _animator = transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isAttack && _enemyCollider != null && !PlayerHealth.IsDeath)
        {
            _enemyCollider.GetComponent<EnemyHealth>().TakeDamage(_damage);
            _animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            _isAttack = true;
            _enemyCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            _isAttack = false;
            _enemyCollider = null;
        }
    }
}
