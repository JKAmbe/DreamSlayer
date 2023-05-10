using UnityEngine;

public class AntiClockwise : MonoBehaviour
{
    public float rotationSpeed = 180f; // how fast the cross rotates in degrees per second

    void Update()
    {
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime, Space.Self); // rotate the cross around its local y-axis
    }
}
