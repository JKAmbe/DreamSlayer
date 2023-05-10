using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float amplitude = 1f; // how far the pendulum swings
    public float frequency = 1f; // how quickly the pendulum swings

    private float angle = 0f; // the current angle of the pendulum

    void Update()
    {
        angle += frequency * Time.deltaTime; // increment the angle based on the frequency and time
        float x = Mathf.Sin(angle) * amplitude; // calculate the x position of the pendulum
        transform.localPosition = new Vector3(x, 25f, 0f); // set the local position of the transform
    }
}