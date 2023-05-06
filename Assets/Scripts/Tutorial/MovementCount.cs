using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCount : MonoBehaviour
{
    public MovementCheck movementCheck1;
    public MovementCheck movementCheck2;
    public MovementCheck movementCheck3;
    public MovementCheck movementCheck4;
    public MovementCheck movementCheck5;
    public MovementCheck movementCheck6;
    public MovementCheck movementCheck7;
    public MovementCheck movementCheck8;
    public MovementCheck movementCheck9;
    public MovementCheck movementCheck10;
    public MovementCheck movementCheck11;
    public MovementCheck movementCheck12;

    public float delay = 3f;

    public GameObject otherGameObject;
    public TextChange1 textChange1;

    // Start is called before the first frame update
    void Start()
    {
        textChange1 = otherGameObject.GetComponent<TextChange1>();
        textChange1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementCheck1.count + movementCheck2.count + movementCheck3.count +
            movementCheck4.count + movementCheck5.count + movementCheck6.count +
            movementCheck7.count + movementCheck8.count + movementCheck9.count +
            movementCheck10.count + movementCheck11.count + movementCheck12.count == 12)
        {
            Invoke("DisableObject" ,delay);
        }
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
        textChange1.enabled = true;
    }
}
