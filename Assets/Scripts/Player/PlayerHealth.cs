using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _invincibleDuration;
    [SerializeField] private float _deathForce;
    [SerializeField] private float _deathTorque;
    [SerializeField] private RectTransform _healtBar;

    private bool _isInvincible;
    private Rigidbody _rigidbody;

    public static bool IsDeath;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float damage)
    {
        _healtBar.offsetMax = new Vector2(-1f * 336f * (100 - _health) / 100, 0);
        
        if(_isInvincible)
        {
            damage = 0;
            _health -= damage;
        }
        else
        {
            _health -= damage;
        }

        if (_health <= 0 && !IsDeath)
        {
            IsDeath = true;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.AddForce(Vector3.up * _deathForce);
            _rigidbody.AddTorque(Vector3.back * _deathTorque);
        }
    }

    public void InvincibilityElixir()
    {
        StartCoroutine(UseInvincibilityElixir(_invincibleDuration));
    }

    IEnumerator UseInvincibilityElixir(float time)
    {
        _isInvincible = true;
        yield return new WaitForSeconds(time);
        _isInvincible = false;
    }
}
