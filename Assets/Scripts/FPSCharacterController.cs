using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed = 2f;
    [SerializeField]
    private Camera _camera;

    private CharacterController _characterController;
    private Vector3 movementInput, treatedInput;

    private void Start()
    {
        if(_camera == null)
        {
            Debug.Log("Player camera has not been assigned in Inspector. Do it or performance may be hindered.");
            _camera = Camera.main;
        }

        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        RotateWithCamera();
        GetMovementInput();
        HorizontalMovement();
    }

    private void GetMovementInput()
    {
        movementInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        //Makes input direction relative to camera and normalized
        treatedInput = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * movementInput;
        treatedInput = new Vector3(treatedInput.x, 0, treatedInput.z).normalized;
    }

    private void HorizontalMovement()
    {
        _characterController.Move(treatedInput * walkingSpeed * Time.deltaTime);
    }

    private void RotateWithCamera()
    {
        transform.rotation = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0);
    }
}
