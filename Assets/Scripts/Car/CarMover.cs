using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
	
	[SerializeField] private float _speed;
	[SerializeField] private float _turnSpeed;

	
	private Rigidbody _rigidbody;
	private float _moveDirection;


	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		
	}

	void Update()
	{

		_moveDirection = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

		_rigidbody.MovePosition(transform.position + transform.forward * _moveDirection);

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * _turnSpeed * Time.deltaTime, 0);
	}
}
