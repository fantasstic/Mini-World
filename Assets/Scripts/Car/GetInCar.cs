using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInCar : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private Transform _seatTransform;
    [SerializeField] private Transform _outPosition;
    [SerializeField] private GameObject _carCamera;

    private bool _isInsideCar;

    private void OnTriggerStay(Collider other)
    {
        var playerRigidbody = other.GetComponent<Rigidbody>();
        var playerCollider = other.GetComponent<CapsuleCollider>();

        if (Input.GetKeyDown(KeyCode.E) && !_isInsideCar)
        {
            if (!_isInsideCar)
            {
                /*playerCollider.enabled = false;*/
                /*playerRigidbody.useGravity = false;
                playerRigidbody.isKinematic = true;*/
                other.gameObject.SetActive(false);
                _carCamera.SetActive(true);
                other.transform.position = _seatTransform.position; 
                other.transform.parent = _car.transform; 
                _isInsideCar = true;
            }
            else
            {
                Debug.Log("Vishel");
                _carCamera.SetActive(false);
                other.gameObject.SetActive(true);
               /* playerCollider.enabled = true;*/
                /*playerRigidbody.isKinematic = false;*/
                other.transform.position = _outPosition.position;
                other.transform.parent = null; 
                _isInsideCar = false;
            }
        }
    }
}

