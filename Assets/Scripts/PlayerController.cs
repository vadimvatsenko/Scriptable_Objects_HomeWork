using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private PlaneCoords _planeCoords;

    private CharacterStats _characterStats;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _planeCoords = FindAnyObjectByType<Plane>()._planeCoords;
        _characterStats = Resources.Load<CharacterStats>("ScriptableObjects/NewCharacterStats");

    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = (horizontal * right) + (vertical * forward).normalized;

        float xClamp = Mathf.Clamp(_rb.transform.position.x, _planeCoords.minX, _planeCoords.maxX);
        float zClamp = Mathf.Clamp(_rb.transform.position.z, _planeCoords.minZ, _planeCoords.maxZ);

        if (moveVector != Vector3.zero)
        {
            _rb.MovePosition(new Vector3(xClamp, _rb.position.y, zClamp) + moveVector * _characterStats.speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(moveVector);

            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, unitRotation, Time.deltaTime * _characterStats.speed));
        }
    }
}
