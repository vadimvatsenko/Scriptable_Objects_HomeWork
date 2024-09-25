using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    private GameObject _target;
    private Vector3 _targetPos;

    [SerializeField] private Vector3 _offsetPos;
    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private float _smooth = 0.5f;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        _target = GameObject.FindWithTag("Player");
        if(_target != null )
        {
            _targetPos = _target.transform.position + _offsetPos;
            transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref _velocity, _smooth);
        }
    }
}
