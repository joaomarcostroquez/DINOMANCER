using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    [Header("Basic movement settings")]
    [SerializeField] private float walkingSpeed = 5f;
    [SerializeField] private float runningSpeed = 10f;

    [Header("Run toggling method")]
    [Tooltip("If checked, shift will toggle running. If unchecked, player must hold shift to run.")]
    [SerializeField] public bool runToggle = true;
    [Tooltip("If runToggle is checked, this is the threshold to automatically switch back to walking when the player stops.")]
    [SerializeField] private float stoppedRunningThreshold = 0.01f;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Vector3 checkOffset;
    [SerializeField] private float checkSphereRadius;
    [SerializeField] private float normalThreshold;

    [Header("Other")]
    [SerializeField] private Camera _camera;

    private CharacterController _characterController;
    private Vector3 movementInput, treatedInput;
    private float movementSpeed;    
    private bool isRunning = false;

    private float verticalVelocity;
    private float groundAngle;
    private Vector3 checkSpherePosition;

    private void Start()
    {
        if(_camera == null)
        {
            Debug.Log("Player camera has not been assigned in Inspector. Do it or performance may be hindered.");
            _camera = Camera.main;
        }

        _characterController = GetComponent<CharacterController>();

        movementSpeed = walkingSpeed;

        //lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateWithCamera();
        GetInput();
        HorizontalMovement();
    }

    private void GetInput()
    {
        movementInput.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        TreatMovementInput();

        ToggleRun();
    }

    private void ToggleRun()
    {
        if (runToggle)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (isRunning)
                    movementSpeed = walkingSpeed;
                else
                    movementSpeed = runningSpeed;

                isRunning = !isRunning;
            }
            else if(treatedInput.magnitude < stoppedRunningThreshold)
            {
                movementSpeed = walkingSpeed;

                isRunning = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSpeed = runningSpeed;
                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movementSpeed = walkingSpeed;
                isRunning = false;
            }
        }
    }

    private void TreatMovementInput()
    {
        //Makes input direction relative to camera and normalized
        treatedInput = Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0) * movementInput;
        treatedInput = new Vector3(treatedInput.x, 0, treatedInput.z);
        if (treatedInput.magnitude > 1)
            treatedInput.Normalize();
    }

    private void HorizontalMovement()
    {
        _characterController.Move(treatedInput * movementSpeed * Time.deltaTime);
    }

    private void RotateWithCamera()
    {
        transform.rotation = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0);
    }
}
