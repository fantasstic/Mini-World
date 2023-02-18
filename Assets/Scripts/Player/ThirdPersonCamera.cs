using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private float _currentX = 0.0f;
    private float _currentY = 15.0f;
    private float _sensitivityX = 20.0f;
    private float _sensitivityY = 20.0f;
    private Transform _camTransform;

    public Transform PlayerLookAt;
    public float Distance = 5.0f;

    private void Start()
    {
        _camTransform = transform;
    }

    private void Update()
    {
        _currentX += Input.GetAxis("Mouse X");
        _currentY += Input.GetAxis("Mouse Y");

        _currentY = Mathf.Clamp(_currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
        _camTransform.position = PlayerLookAt.position + rotation * dir;
        _camTransform.LookAt(PlayerLookAt.position);
    }
}
