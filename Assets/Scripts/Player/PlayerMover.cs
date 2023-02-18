using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour 
{
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _speed;
	[SerializeField] private float _turnSpeed;

	private Animator _animator;
	private Rigidbody _rigidbody;
	private float _moveDirection;


	void Start()
	{
			_rigidbody = GetComponent <Rigidbody>();
			_animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (Input.GetKey ("w")) 
		{
			_animator.SetInteger ("AnimationPar", 1);
		}  
		else 
		{
     	    _animator.SetInteger ("AnimationPar", 0);
		}

		if (_rigidbody.velocity.y == 0)
			_animator.SetBool("isJump", false);

		if(Input.GetKeyDown(KeyCode.Space) && _rigidbody.velocity.y == 0)
        {
			_rigidbody.AddForce(Vector3.up * _jumpForce);
			_animator.SetTrigger("Jumping");
			_animator.SetBool("isJump", true);
		}

		_moveDirection = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

		_rigidbody.MovePosition(transform.position + transform.forward * _moveDirection);

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * _turnSpeed * Time.deltaTime, 0);			
	}
}
