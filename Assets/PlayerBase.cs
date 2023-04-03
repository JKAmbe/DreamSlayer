using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    
    [Header("Firing System")]
    public GameObject pew;
    public Transform spawn;
    public float DistancePoint = 250f;
    public float pewForce = 4f;
    public int duration = 1;
    public float maxBeamSize = 10;
    public bool mouseAim = true;
    private float beamSize = 0;

    [Header("Movement System")]
    public int playerSpeed;
    public Vector2 AxisDamping;
    public Vector3 directionRange;
    public float RotationSpeed = 4;
    CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * AxisDamping.x, Input.GetAxis("Vertical") * AxisDamping.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        Quaternion rotation = Quaternion.Euler(new Vector3(-move.y * directionRange.x, move.x * directionRange.y, -move.x * directionRange.z));
        Quaternion SmoothedRotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        transform.rotation = SmoothedRotation;
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            ChargeBeam();
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log(beamSize);
            FireBeam();
        }
    }

    private void FireBeam()
    {
        Vector3 Direction = mouseAim ? new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, DistancePoint).normalized : transform.forward;
        float tmp = Mathf.Pow(3, beamSize);
        GameObject pewTmp = Instantiate(pew, spawn.position, Quaternion.identity, transform.parent);
        pewTmp.transform.localScale = pewTmp.transform.localScale * tmp;
        pewTmp.GetComponent<Rigidbody>().AddForce(Direction* pewForce);
        Destroy(pewTmp, duration);
        beamSize = 0;
    }

    private void ChargeBeam()
    {
        beamSize += Time.deltaTime;
        beamSize = Mathf.Clamp(beamSize, 0, maxBeamSize);
    }
}
