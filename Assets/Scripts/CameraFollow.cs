using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float mouseStrength = 2f;
    public Vector3 offset;
    public bool mouseEffect = false;

    private void FixedUpdate()
    {
        Vector3 offsetMouse = mouseEffect ? offset + new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0) * mouseStrength / 1000: offset;
        Vector3 desiredPosition = target.position + offsetMouse;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(smoothedPosition);
    }
}
