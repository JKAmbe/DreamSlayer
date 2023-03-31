using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpMovement : MonoBehaviour
{
    CharacterController controller;
    public int playerSpeed;
    public Vector2 AxisDamping;
    public Vector3 directionRange;
    public float RotationSpeed = 4;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal")* AxisDamping.x, Input.GetAxis("Vertical") * AxisDamping.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        Quaternion rotation = Quaternion.Euler(new Vector3(-move.y * directionRange.x, move.x * directionRange.y, -move.x*directionRange.z));
        Quaternion SmoothedRotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        transform.rotation = SmoothedRotation;


        //Vector3 offsetMouse = offset + new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0) * mouseStrength / 1000;
        //Vector3 desiredPosition = target.position + offsetMouse;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;
    }
}
