using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0;

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontalInput * _speed * Time.deltaTime, verticalInput * _speed * Time.deltaTime, 0);
    }
}
