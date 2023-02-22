using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoPotion : MonoBehaviour
{
    [SerializeField] private float _timeScaleChangeSpeed = 1;
    [SerializeField] private float _slowMotionDuration = 5;
    [SerializeField] private float _slowMotionMax = 0.1f;

    private bool _isSlowMotion;
    private float _currentSlowMotionDuration;

    private void Update()
    {
        if (_isSlowMotion)
        {
            DoSlowMotion();
        }
    }

    public void SlowMotionButton()
    {
        StartSlowMotion();
    }

    public void StartSlowMotion()
    {
        _isSlowMotion = true;

        _currentSlowMotionDuration = _slowMotionDuration;
    }

    public void StopSlowMotion()
    {
        _isSlowMotion = false;

        Time.timeScale = 1;
    }

    private void DoSlowMotion()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale - _timeScaleChangeSpeed * Time.unscaledDeltaTime, _slowMotionMax, 1);

        _currentSlowMotionDuration -= Time.unscaledDeltaTime;

        if (_currentSlowMotionDuration < 0)
        {
            StopSlowMotion();
        }
    }
}
