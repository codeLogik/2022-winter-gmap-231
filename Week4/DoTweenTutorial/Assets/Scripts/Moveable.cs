using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] private float _speedMetersPerSecond = 25f;

    // Private variables for managing state of the moveable
    private Vector3? _destination;
    private Vector3 _startPosition;
    private float _totalLerpDuration;
    private float _elapsedLerpDuration;
    private Action _onCompleteCallback;

    // Update is called once per frame
    void Update()
    {
        // Determine that we have a destination before continuing.
        if (!_destination.HasValue) { return; }

        // Ensure that the elapsed time of the lerp has not exceeded the total time allowed for the lerp.
        if (_elapsedLerpDuration >= _totalLerpDuration && _totalLerpDuration > 0) { return; }

        // Update the lerp duration and determine the percentage complete of the lerp.
        _elapsedLerpDuration += Time.deltaTime;
        float percent = _elapsedLerpDuration / _totalLerpDuration;

        // Lerp the position of the object from the start position to the destination at the current percentage.
        transform.position = Vector3.Lerp(_startPosition, _destination.Value, percent);

        // Call the on complete callback if we have reached the end of the total lerp duration.
        if (_elapsedLerpDuration > _totalLerpDuration)
        {
            _onCompleteCallback?.Invoke();
        }
    }

    public void MoveTo(Vector3 destination, Action onComplete = null)
    {
        // Set up the move controller to perform a move of the moveable to the new destination.
        var distanceToNextWaypoint = Vector3.Distance(transform.position, destination);
        _totalLerpDuration = distanceToNextWaypoint / _speedMetersPerSecond;

        _startPosition = transform.position;
        _destination = destination;
        _elapsedLerpDuration = 0;
        _onCompleteCallback = onComplete;
    }
}
