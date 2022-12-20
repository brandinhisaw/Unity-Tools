using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float cameraRotateSpeed;
    [SerializeField]
    float yawSpeed;

    float yaw;

    PlayerCameraController playerCameraController;
    CharacterController controller;

    float forwardMovement;
    float lateralMovement;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCameraController = GetComponentInChildren<PlayerCameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardMovement = Input.GetAxis("Vertical");
        lateralMovement = Input.GetAxis("Strafe");

        if (Input.GetMouseButton(1))
        {
            // prevents camera from moving
            playerCameraController.StopCameraReset();
            playerCameraController.ResetCamera(true);

            // rotate player instead of camera, camera attached to player transform
            yaw = Input.GetAxis("Mouse X") * cameraRotateSpeed;
            RotatePlayer(yaw);

            // strafe while holding mouse 1
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f)
            {
                lateralMovement = Input.GetAxisRaw("Horizontal");
            }
        }
        else if (Input.GetMouseButton(0))
        {
            playerCameraController.StopCameraReset();

            playerCameraController.RotateCamera();

            yaw = Input.GetAxis("Horizontal");
            RotatePlayer(yaw);
        }
        else
        {
            yaw = Input.GetAxis("Horizontal");
            RotatePlayer(yaw);
        }
        

        if (!Input.GetMouseButtonUp(0) && Mathf.Abs(forwardMovement) > 0.0f)
        {
            playerCameraController.ResetCamera(false);
        }

        controller.Move(transform.right * lateralMovement * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * forwardMovement * moveSpeed * Time.deltaTime);
    }

    void RotatePlayer(float yaw)
    {
        {
            transform.Rotate(transform.up * yaw * yawSpeed * Time.deltaTime);
        }
    }
}
