﻿using UnityEngine;
using UnityEngine.Events;

public class WristMenuPoseDetector : MonoBehaviour {

    public Transform CameraTransform;
    public UnityEvent OnPoseEnter;
    public UnityEvent OnPoseExit;
    public float InnerWindowCameraDotThreshold = -0.8f;
    float _innerWindowCameraDot = 0;
    bool _inPose = false;

    void Start () {
        if (CameraTransform == null)
        {
            Debug.LogWarning("No CameraTransform assigned, using Camera.main", this);
            CameraTransform = Camera.main.transform;
        }
	}

    void Update()
    {
        _innerWindowCameraDot = Vector3.Dot(CameraTransform.transform.forward, transform.forward);

        //Debug.Log(_innerWindowCameraDot);
        bool currentlyPosed = !(_innerWindowCameraDot > 0.34f);
        if (_inPose != currentlyPosed)
        {
           // Debug.Log(_inPose);
            _inPose = currentlyPosed;
            if (_inPose)
            {
                OnPoseEnter.Invoke();
            }
            else {
                OnPoseExit.Invoke();
            }
        }
    }
}
