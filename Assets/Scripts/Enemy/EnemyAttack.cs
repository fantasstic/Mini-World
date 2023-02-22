using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private NavMeshAgent _enemyAgent;
    private Coroutine _damageCoroutine;
    private Animator _animator;

    private void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(_enemyAgent.enabled)
                _enemyAgent.SetDestination(other.transform.parent.gameObject.transform.position);
        }

        if(other.CompareTag("Attack"))
        {
            if(_damageCoroutine == null)
            {
                _damageCoroutine = StartCoroutine(SetDamage(other));
                _animator.SetBool("isAttack", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<EnemyMover>().SetNewPath();
        }

        if (other.CompareTag("Attack"))
        {
            StopCoroutine(_damageCoroutine);
            _damageCoroutine = null;
            _animator.SetBool("isAttack", false);
        }
    }

    IEnumerator SetDamage(Collider attackCollider)
    {
        while(true)
        {
            if(_enemyAgent.enabled)
                attackCollider.transform.parent.GetComponent<PlayerHealth>().TakeDamage(_damage);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
