using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _deathForce;
    [SerializeField] private float _deathTorque;
    [SerializeField] private GameObject _healthBar;

    public bool IsDeath;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_healthBar != null)
            _healthBar.transform.localScale = new Vector3(_health / 100f, 0.1f, 0.001f);

        if (_health <= 0 && !IsDeath)
        {
            IsDeath = true;
            Destroy(_healthBar);
            GetComponent<Animator>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;

            _rigidbody.constraints = RigidbodyConstraints.None;
            /*_rigidbody.AddForce(Vector3.up * _deathForce);
            _rigidbody.AddTorque(Vector3.back * _deathTorque);*/
        }
    }
}