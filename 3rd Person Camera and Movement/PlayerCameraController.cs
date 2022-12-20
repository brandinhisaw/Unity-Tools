using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] float cameraResetDelay = 1.0f;

    [SerializeField] float cameraRotateSpeed = 100.0f;
    [SerializeField] float zoomSpeed = 0.1f;
    
    CinemachineVirtualCamera playerCam;
    CinemachineTrackedDolly trackedDolly;

    Quaternion originalLocalRotation;

    // Start is called before the first frame update
    void Start()
    {       
        playerCam = GetComponentInChildren<CinemachineVirtualCamera>();
        trackedDolly = playerCam.GetCinemachineComponent<CinemachineTrackedDolly>();

        originalLocalRotation = transform.localRotation;    
    }

    // Update is called once per frame
    void Update()
    {
        trackedDolly.m_PathPosition = Mathf.Clamp(trackedDolly.m_PathPosition + Input.mouseScrollDelta.y * zoomSpeed, 0, 10);
    }

    public void ResetCamera(bool skipDelay)
    {        
        StartCoroutine(ResetCameraCoroutine(skipDelay));
    }

    public void RotateCamera()
    {
        var mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(new Vector3 (0, mouseX * cameraRotateSpeed * Time.deltaTime, 0));
    }

    public void StopCameraReset()
    {
        StopAllCoroutines();
    }

    // created this coroutine with help from the Unity Forum: https://forum.unity.com/threads/rotate-spin-object-360-degrees-over-set-time-in-coroutine.395332/
    IEnumerator ResetCameraCoroutine(bool skipDelay)
    {
        if (!skipDelay)
        {
            yield return new WaitForSeconds(cameraResetDelay);
        }

        while (transform.localRotation != originalLocalRotation)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, originalLocalRotation, cameraRotateSpeed * Time.deltaTime);

            yield return null;
        }
    }

}
