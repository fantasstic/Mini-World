using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInCar : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private Transform _seatTransform;
    [SerializeField] private Transform _outPosition;
    [SerializeField] private GameObject _carCamera;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private CarMover _carMover;

    private bool _isInsideCar = false;

    private void Update()
    {
        if(_isInsideCar)
        {
            _player.transform.position = _seatTransform.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var playerRigidbody = other.GetComponent<Rigidbody>();
        var playerCollider = other.GetComponent<CapsuleCollider>();
        var playerMover = other.GetComponent<PlayerMover>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isInsideCar)
            {
                playerMover.enabled = false;
                playerCollider.isTrigger = true;
                playerRigidbody.useGravity = false;
                _playerCamera.SetActive(false);
                _carCamera.SetActive(true);
                other.transform.position = _seatTransform.position;
                other.transform.parent = _car.transform; 
                _isInsideCar = true;
                _carMover.enabled = true;
            }
            else
            {
                playerCollider.isTrigger = false;
                playerRigidbody.useGravity = true;
                playerMover.enabled = true;
                _carCamera.SetActive(false);
                _playerCamera.SetActive(true);
                other.transform.position = _outPosition.position;
                other.transform.parent = null;
                _isInsideCar = false;
                _carMover.enabled = false;
            }
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 
            if (_isInsideCar)
            {
                Debug.Log("Vishel");
                _carCamera.SetActive(false);
                _player.SetActive(true);
                _player.transform.position = _outPosition.position;
                _player.transform.parent = null;
                _isInsideCar = false;
            }
        }
    }*/

}

